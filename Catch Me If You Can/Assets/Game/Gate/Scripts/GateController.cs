using System.Collections;
using UnityEngine;
using Mirror;

public class GateController : NetworkBehaviour
{
    [SerializeField] private Animator _animator;

    [SyncVar(hook = nameof(OnRequiredCounterChanged))]
    [SerializeField] private int _requiredCounter;

    [SyncVar(hook = nameof(OnCounterChanged))]
    [SerializeField] private int _gateCounter;

    [SyncVar(hook = nameof(OnMatchReady))] 
    [SerializeField] private bool _matchStarted = false;

    private void OnRequiredCounterChanged(int oldValue, int newValue)
    {
        _requiredCounter = newValue;
    }

    private void OnCounterChanged(int oldValue, int newValue)
    {
        _gateCounter = newValue;

        if (newValue == _requiredCounter)
        {
            _matchStarted = true;
            _animator.Play("GateOpen");
            StartCoroutine(StartMatch());
        }
    }

    private void OnMatchReady(bool oldValue, bool newValue)
    {
        _matchStarted = newValue;
    }

    public void IncreaseGateCounter()
    {
        if (_matchStarted) return;
        _gateCounter++;
    }

    public void DecreaseGateCounter()
    {
        if (_matchStarted) return;
        _gateCounter--;
    }

    public void SetRequiredCounter(int amount)
    {
        _requiredCounter = amount;
    }

    private void DisableTriggers()
    {
        Trigger[] triggers = GetComponentsInChildren<Trigger>();

        foreach (Trigger trigger in triggers)
        {
            trigger.enabled = false;
        }
    }

    private IEnumerator StartMatch()
    {
        DisableTriggers();

        yield return new WaitForSecondsRealtime(3f);

        if (isServer)
        {
            FindObjectOfType<NetworkMatchState>().StartTheMatch();
        }
    }
}
