using Mirror;
using System.Collections;
using UnityEngine;

public class PlayerState : NetworkBehaviour
{
    [Header("Player state")]
    [SerializeField] private Light _stateLight;
    [SerializeField] private bool _onCooldown;
    [SerializeField] private bool _isCaught;

    [Header("UI references")]
    [SerializeField] private PlayerInterface _playerInterface;

    private void Start()
    {
        StateColor.Set(_stateLight, _playerInterface, StateColor.Neutral);

        if (isServer) gameObject.name = "Server: " + gameObject.name;
        else gameObject.name = "Client: " + gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || _onCooldown)
            return;

        // Keep the is server check here to prevent any calls to the NetworkMatchState when not the client
        if (isServer)
        {
            FindAnyObjectByType<NetworkMatchState>().ServerChangeStates();
        }
    }

    /// <summary>
    /// This method will be called on change state by the client
    /// </summary>
    /// <param name="state"></param>
    private void ChangeColors(bool state)
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
                break;

            case true:
                StateColor.Set(_stateLight, _playerInterface, StateColor.Seek);
                break;
        }
    }

    /// <summary>
    /// Call this to set the player state
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
}
