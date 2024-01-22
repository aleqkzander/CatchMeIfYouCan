using System.Collections;
using UnityEngine;
using Mirror;

public class GateController : NetworkBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private int requiredCount = 2; // keep serialized for debugging. Remove serialized flag on production.
    private int gateCounter;

    public override void OnStartClient()
    {
        base.OnStartClient();

        //requiredCount++;
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        //requiredCount++;
    }

    public void IncreaseGateCounter()
    {
        gateCounter++;

        if (gateCounter == requiredCount)
        {
            StartCoroutine(OpenTheGate());
        }
    }

    public void DecreaseGateCounter()
    {
        gateCounter--;
    }

    private IEnumerator OpenTheGate()
    {
        DisableTriggers();
        OpenGate();
        
        yield return new WaitForSecondsRealtime(3f);

        if (isServer)
        {
            // Server check is required because NetworkMatchState gets destroyed when not the server.
            FindObjectOfType<NetworkMatchState>().StartTheMatch();
        }
    }

    private void DisableTriggers()
    {
        Trigger[] triggers = GetComponentsInChildren<Trigger>();

        foreach (Trigger trigger in triggers)
        {
            trigger.enabled = false;
        }
    }

    private void OpenGate()
    {
        _animation.Play("OpenGate");
    }
}
