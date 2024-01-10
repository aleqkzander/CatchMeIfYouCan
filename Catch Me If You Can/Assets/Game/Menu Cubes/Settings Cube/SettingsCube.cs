using TMPro;
using UnityEngine;

public class SettingsCube : MonoBehaviour
{
    public TMP_InputField NicknameEntry;

    private void Start()
    {
        SetNameFromSavegame();
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenCube();
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void OpenCube()
    {
        GetComponent<Animation>().Play("CubeShow");
        DataManager.Instance.Mouse.Enable();
        DataManager.Instance.Movement.Enabled = false;
    }

    private void CloseCube()
    {
        GetComponent<Animation>().Play("CubeHide");
        DataManager.Instance.Mouse.Disable();
        DataManager.Instance.Movement.Enabled = true;
    }

    private void SetNameFromSavegame()
    {
        string savedName = DataManager.Instance.User.Name;

        if (string.IsNullOrEmpty(savedName))
        {
            NicknameEntry.text = "Unnamed";
        }
        else
        {
            NicknameEntry.text = DataManager.Instance.User.Name;
        }
    }

    public void Cube_SetNickname()
    {
        if (string.IsNullOrEmpty(NicknameEntry.text)) return;
        DataManager.Instance.User.Name = NicknameEntry.text;
        DataManager.Instance.SaveGame();
    }

    public void Cube_ResetSavegame()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Savegame deleted. Exit game");
        Application.Quit();
    }
}
