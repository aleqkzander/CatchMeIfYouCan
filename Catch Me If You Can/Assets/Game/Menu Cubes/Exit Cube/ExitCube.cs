using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
