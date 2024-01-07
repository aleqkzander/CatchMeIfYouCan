using System.Collections;
using UnityEngine;

public class StateColor
{
    public static Color Neutral = new(0.6078432f, 0.3490196f, 0.7137255f);
    public static Color Hide = new(0.1803922f, 0.8f, 0.4431373f);
    public static Color Seek = new(0.9058824f, 0.2980392f, 0.2352941f);
}

public class PlayerState : MonoBehaviour
{
    [SerializeField] private Light _stateLight;
    private bool _onCooldown;

    private void Awake()
    {
        _stateLight.color = StateColor.Neutral;
        SetColor( _stateLight.color );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_onCooldown) return;
    }

    private IEnumerator HandleCooldown()
    {
        _onCooldown = true;
        yield return new WaitForSecondsRealtime(3);
        _onCooldown = false;
    }

    public void SetCooldown()
    {
        StartCoroutine(HandleCooldown());
    }

    public void SetColor(Color color)
    {
        _stateLight.color = color;
        GetComponent<PlayerInterface>().SetStatusColor(color);
    }
}
