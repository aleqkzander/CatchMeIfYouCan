using UnityEngine;

[System.Serializable]
public class Movement
{
    public bool IsEnabled = true;

    public void Enable()
    {
        IsEnabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Disable()
    {
        IsEnabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
