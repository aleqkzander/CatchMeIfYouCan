using Mirror;
using System.Collections;
using UnityEngine;

public class PlayerState : NetworkBehaviour
{
    [SerializeField] private Light _stateLight;
    private bool _onCooldown;
    private bool _isCaught;


    private void Awake()
    {
        _stateLight.color = StateColor.Neutral;
        SetColor( _stateLight.color );
    }

    public bool IsOnCooldown()
    {
        return _onCooldown;
    }

    public bool IsCaught()
    {
        return _isCaught;
    }

    public void SetState(bool state)
    {
        _isCaught = state;
        SetCooldown();
        HandleColor( state );
    }

    private void SetCooldown()
    {
        StartCoroutine(HandleCooldown());
    }

    private IEnumerator HandleCooldown()
    {
        _onCooldown = true;
        yield return new WaitForSecondsRealtime(3);
        _onCooldown = false;
    }

    private void HandleColor(bool state)
    {
        switch (state)
        {
            case false:
                SetColor(StateColor.Hide);
                break;
            case true:
                SetColor(StateColor.Seek);
                break;
        }
    }

    private void HandleColorCommand()
    {

    }

    private void HandleColorClientRpc()
    {

    }

    private void SetColor(Color color)
    {
        _stateLight.color = color;
        GetComponent<PlayerInterface>().SetStatusColor(color);
    }
}
