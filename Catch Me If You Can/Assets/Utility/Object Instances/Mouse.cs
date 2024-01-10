using UnityEngine;

[System.Serializable]
public class Mouse
{
    public void Disable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Enable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
