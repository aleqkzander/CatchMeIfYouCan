using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
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
            gateController.IncreaseGateCounter();
            _animation.Play("KnobDown");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gateController.DecreaseGateCounter();
            _animation.Play("KnobUp");
        }
    }
}
