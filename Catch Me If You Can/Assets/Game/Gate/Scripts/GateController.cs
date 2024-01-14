using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using Mirror;

public class GateController : NetworkBehaviour
{
    [SerializeField] private Animation _animation;
    private readonly int requiredCount = 2;
    private int gateCounter;

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
        DataManager.Instance.Movement.Disable();
        _animation.Play("OpenGate");
        yield return new WaitForSecondsRealtime(3f);

        if (isServer)
        {
            // Server check is required because GameObject gets destroyed when not the server.
            FindAnyObjectByType<NetworkMatchState>().StartTheMatch();
        }

        DataManager.Instance.Movement.Enable();
    }
}
