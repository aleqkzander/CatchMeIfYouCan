using UnityEngine;
using Mirror;

public class Trigger : NetworkBehaviour
{
    [SerializeField] private GateController gateController;
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponentInChildren<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isServer)
            {
                EnterKnobClientRpc();
            }
            else
            {
                if (isOwned)
                {
                    EnterKnobCommand();
                }
            }

            _animation.Play("KnobDown");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isServer)
            {
                ExitKnobClientRpc();
            }
            else
            {
                if (isOwned)
                {
                    ExitKnobCommand();
                }
            }

            _animation.Play("KnobUp");
        }
    }

    [Command]
    private void EnterKnobCommand()
    {
        EnterKnobClientRpc();
    }

    [ClientRpc]
    private void EnterKnobClientRpc()
    {
        gateController.IncreaseGateCounter();
    }

    [Command]
    private void ExitKnobCommand()
    {
        ExitKnobClientRpc();
    }

    [ClientRpc]
    private void ExitKnobClientRpc()
    {
        gateController.DecreaseGateCounter();
    }
}
