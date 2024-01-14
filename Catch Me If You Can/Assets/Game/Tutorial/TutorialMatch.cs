/*
 * The tutorial match is simulating the server functionality
 */

using UnityEngine;

public class TutorialMatch : MonoBehaviour
{
    private PlayerStateTutorial _playerState;
    private float _playerTimer = 60f;

    private void Awake()
    {
        _playerState = FindAnyObjectByType<PlayerStateTutorial>();
    }

    private void Update()
    {
        if (_playerState.IsCaught() && _playerTimer > 0)
        {
            _playerTimer -= Time.deltaTime;
        }

        _playerState.GetComponent<PlayerInterface>().SetPlayerTime(_playerTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_playerState.IsOnCooldown()) return;


        if (_playerState.IsCaught())
        {
            _playerState.SetState(false);
        }
        else 
        { 
            _playerState.SetState(true); 
        }
    }
}
