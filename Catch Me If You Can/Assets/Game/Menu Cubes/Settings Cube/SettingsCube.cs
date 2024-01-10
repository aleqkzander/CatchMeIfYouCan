using TMPro;
using UnityEngine;

public class SettingsCube : MonoBehaviour
{
    public TMP_InputField NicknameEntry;

    private void Start()
    {
        SetNameFromSavegame();
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

    private void OnTriggerEnter(Collider other)
    {
        OpenCube();
    }

    private void OpenCube()
    {
        GetComponent<Animation>().Play("CubeShow");
        GetComponent<InterfaceController>().EnableMouse();
    }

    public void Cube_CloseCube()
    {
        GetComponent<Animation>().Play("CubeHide");
        GetComponent<InterfaceController>().DisableMouse();
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
