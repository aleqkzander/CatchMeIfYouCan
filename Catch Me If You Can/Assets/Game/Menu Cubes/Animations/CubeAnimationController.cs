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

    public void OpenCube()
    {
        //Savegame.Instance.Movement.isDisabled = true;
        //Savegame.Instance.Mouse.Show();
        _animation.Play("OpenCube");
    }

    public void CloseCube()
    {
        //Savegame.Instance.Movement.isDisabled = false;
        //Savegame.Instance.Mouse.Hide();
        _animation.Play("CloseCube");
    }
}
