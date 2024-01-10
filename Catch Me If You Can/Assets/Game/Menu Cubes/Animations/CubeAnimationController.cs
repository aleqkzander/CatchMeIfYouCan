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
        CloseCube();
    }

    private void OpenCube()
    {
        _animation.Play("CubeShow");
        DataManager.Instance.Mouse.Enable();
    }

    private void CloseCube()
    {
        _animation.Play("CubeHide");
        DataManager.Instance.Mouse.Disable();
    }
}
