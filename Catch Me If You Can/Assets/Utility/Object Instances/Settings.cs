/*
 * Use this to store player settings
 */

using UnityEngine;

[System.Serializable]
public class Settings
{
    public string LastIp = "127.0.0.1";
    [Range(0.2f, 100f)]
    public float CameraSensitivity = 0.5f;
    public bool PostProcessing = true;
    public bool PlayMusic = true;
}
