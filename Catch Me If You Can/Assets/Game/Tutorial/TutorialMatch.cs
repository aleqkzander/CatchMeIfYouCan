/*
 * The tutorial match is simulating the server functionality
 */

using UnityEngine;
using UnityEngine.Playables;

public class TutorialMatch : MonoBehaviour
{
    public PlayerState PlayerState;
    private float _playerTimer = 60f;

    private void Update()
    {
        PlayerState.GetComponent<PlayerInterface>().SetPlayerTime(_playerTimer);

        if (PlayerState.IsCaught() && _playerTimer > 0)
        {
            _playerTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerState.OnCooldown()) return;

        StartCoroutine(PlayerState.HandleTick());
        if (PlayerState.IsCaught())
        {
            PlayerState.SetState(false);
        }
        else 
        {
            PlayerState.SetState(true);
        }
        StartCoroutine(PlayerState.HandleCooldown());
    }
}
