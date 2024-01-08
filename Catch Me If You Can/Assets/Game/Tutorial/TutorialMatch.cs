using UnityEngine;

public class TutorialMatch : MonoBehaviour
{
    public PlayerState Player;
    private float _playerTimer = 60f;

    private void Update()
    {
        if (Player.IsCaught() && _playerTimer > 0)
        {
            _playerTimer -= Time.deltaTime;
        }

        Player.GetComponent<PlayerInterface>().SetPlayerTime(_playerTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.IsOnCooldown()) return;

        if (Player.IsCaught() == true) 
            Player.SetState(false);

        else if (Player.IsCaught() == false)
            Player.SetState(true);
    }
}
