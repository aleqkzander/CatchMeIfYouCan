using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsCube : MonoBehaviour
{
    public TMP_InputField NicknameEntry;

    private void Start()
    {
        //NicknameEntry.text = Savegame.Instance.Meta.Name;
    }

    public void Cube_SetNickname()
    {
        if (string.IsNullOrEmpty(NicknameEntry.text)) return;
        //Savegame.Instance.Meta.Name = NicknameEntry.text;
        //NicknameEntry.text = Savegame.Instance.Meta.Name;
        //Savegame.Instance.SaveGame();
    }

    public void Cube_ResetSavegame()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Savegame deleted exit game");
        Application.Quit();
    }
}
