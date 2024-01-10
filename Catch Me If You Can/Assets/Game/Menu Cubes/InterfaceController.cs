using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public void EnableMouse()
    {
        DataManager.Instance.Mouse.Enable();
        DataManager.Instance.Movement.Enabled = false;
    }

    public void DisableMouse()
    {
        DataManager.Instance.Mouse.Disable();
        DataManager.Instance.Movement.Enabled = true;
    }
}
