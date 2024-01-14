/*
 * The tutorial match is simulating the server functionality
 */

using UnityEngine;

public class TutorialMatch : MonoBehaviour
{
    public PlayerState PlayerState;
    private float _playerTimer = 60f;

    private void Update()
    {
        if (PlayerState.IsCaught() && _playerTimer > 0)
        {
            _playerTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerState.OnCooldown()) return;


        if (PlayerState.IsCaught())
        {
            PlayerState.SetState(false);
        }
        else 
        {
            PlayerState.SetState(true); 
        }
    }
}
