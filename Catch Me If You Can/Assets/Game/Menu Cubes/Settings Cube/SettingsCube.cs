using TMPro;
using UnityEngine;

public class SettingsCube : MonoBehaviour
{
    public TMP_InputField NicknameEntry;

    private void OnTriggerEnter(Collider other)
    {
        NicknameEntry.text = DataManager.Instance.User.Name;
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
