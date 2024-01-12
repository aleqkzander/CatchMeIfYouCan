using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimationController : MonoBehaviour
{
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenCube();
    }

    private void OnTriggerExit(Collider other)
    {
        // Closing the cube Will be trigger by a button new
    }

    private void OpenCube()
    {
        _animation.Play("CubeShow");
        DataManager.Instance.Movement.Disable();
    }

    public void CloseCube()
    {
        _animation.Play("CubeHide");
        DataManager.Instance.Movement.Enable();
    }
}
