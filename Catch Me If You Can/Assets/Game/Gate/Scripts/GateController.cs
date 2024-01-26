using System.Collections;
using UnityEngine;
using Mirror;
using Unity.VisualScripting;

public class GateController : NetworkBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private int _requiredCounter = 2;

    [SyncVar(hook = nameof(OnCounterChanged))]
    [SerializeField] private int _gateCounter;

    [SyncVar(hook = nameof(OnMatchStarted))]
    [SerializeField] private bool _matchStarted = false;

    private void OnCounterChanged(int oldValue, int newValue)
    {
        _gateCounter = newValue;
    }

    private void OnMatchStarted(bool oldValue, bool newValue)
    {
        _matchStarted = newValue;

        if (newValue == true)
        {
            StartCoroutine(OpenTheGate());
        }
    }

    public void IncreaseGateCounter()
    {
        if (_matchStarted) return;

        _gateCounter++;

        if (_gateCounter == _requiredCounter)
        {
            _matchStarted = true;
        }
    }

    public void DecreaseGateCounter()
    {
        if (_matchStarted) return;
        _gateCounter--;
    }

    private void DisableTriggers()
    {
        Trigger[] triggers = GetComponentsInChildren<Trigger>();

        foreach (Trigger trigger in triggers)
        {
            trigger.enabled = false;
        }
    }

    private IEnumerator OpenTheGate()
    {
        _animation.Play("OpenGate");
        DisableTriggers();

        yield return new WaitForSecondsRealtime(3f);

        if (isServer)
        {
            FindObjectOfType<NetworkMatchState>().StartTheMatch();
        }
    }
}
