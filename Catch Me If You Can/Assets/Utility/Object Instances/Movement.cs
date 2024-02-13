using UnityEngine;

[System.Serializable]
public class Movement
{
    public bool IsEnabled = true;

    public void Enable()
    {
        IsEnabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Disable()
    {
        IsEnabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
