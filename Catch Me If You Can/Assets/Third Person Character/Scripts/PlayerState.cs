using Mirror;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : NetworkBehaviour
{
    [Header("Player state")]
    [SerializeField] private Light _stateLight;
    [SerializeField] private bool _onCooldown;
    [SerializeField] private bool _isCaught;
    [SerializeField] private AudioClip _changeStateClip;

    [Header("UI references")]
    [SerializeField] private PlayerInterface _playerInterface;

    [Header("Hand IK annimator")]
    [SerializeField] private Animator _handIKAnimator;

    private void Start()
    {
        StateColor.Set(_stateLight, _playerInterface, StateColor.Neutral);

        if (isServer) gameObject.name = "Server: " + gameObject.name;
        else gameObject.name = "Client: " + gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || _onCooldown) return;

        if (isServer)
        {
            // Keep the is server check here to prevent any calls to the NetworkMatchState when not the client
            FindAnyObjectByType<NetworkMatchState>().ServerChangeStates();
        }
    }

    /// <summary>
    /// This method will be called on change state by the client
    /// </summary>
    /// <param name="state"></param>
    private void ChangeColors(bool state)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            switch (state)
            {
                case false:
                    StateColor.Set(_stateLight, _playerInterface, StateColor.Hide);
                    break;

                case true:
                    StateColor.Set(_stateLight, _playerInterface, StateColor.Seek);
                    break;
            }

            AudioSource.PlayClipAtPoint(_changeStateClip, gameObject.transform.position);
            return;
        }
        else
        {
            if (isServer)
            {
                ChangeColorsClientRpc(state);
            }
            else
            {
                if (isOwned)
                {
                    ChangeColorsCommand(state);
                }
            }
        }
    }

    [Command]
    private void ChangeColorsCommand(bool state)
    {
        ChangeColorsClientRpc(state);
    }

    [ClientRpc]
    private void ChangeColorsClientRpc(bool state)
    {
        switch (state)
        {
            case false:
                StateColor.Set(_stateLight, _playerInterface, StateColor.Hide);
                StartCoroutine(HandleTick()); // also handle the ticking here
                break;

            case true:
                StateColor.Set(_stateLight, _playerInterface, StateColor.Seek);
                break;
        }

        AudioSource.PlayClipAtPoint(_changeStateClip, gameObject.transform.position);
    }

    /// <summary>
    /// Should only be called by NetworkMatchState.cs
    /// </summary>
    /// <param name="state"></param>
    public void SetState(bool state)
    {
        _isCaught = state;
        ChangeColors(state);
    }

    /// <summary>
    /// Call  this method to get current state
    /// </summary>
    /// <returns></returns>
    public bool IsCaught()
    {
        return _isCaught;
    }

    /// <summary>
    /// Call this method to get current cooldown state
    /// </summary>
    /// <returns></returns>
    public bool OnCooldown()
    {
        return _onCooldown;
    }

    /// <summary>
    /// Call this method to handle the cooldown for all clients
    /// </summary>
    /// <returns></returns>
    public IEnumerator HandleCooldown()
    {
        _onCooldown = true;
        yield return new WaitForSecondsRealtime(3);
        _onCooldown = false;
    }

    /// <summary>
    /// Call this method to handle the ticking hand
    /// </summary>
    /// <returns></returns>
    public IEnumerator HandleTick()
    {
        /*
         * control the ik animator from the rig
         */

        _handIKAnimator.enabled = true;
        _handIKAnimator.SetTrigger("Tick");
        yield return new WaitForSecondsRealtime(_handIKAnimator.GetCurrentAnimatorClipInfo(0).Length);
        _handIKAnimator.enabled = false;
    }
}
