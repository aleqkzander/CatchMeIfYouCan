using UnityEngine;

[System.Serializable]
public class Movement
{
    public bool IsEnabled = true;

    public void Enable()
    {
        IsEnabled = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Disable()
    {
        IsEnabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
