using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public User User;
    public Settings Settings;
    public Level CurrentLevel;
    public List<Level> Levels;
    public Movement Movement;
    public List<Material> Materials;

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            LoadUserObject();
            LoadSettingsObject();
        }
    }

    private void LoadUserObject()
    {
        string jsonUser = PlayerPrefs.GetString("jsonuser");

        if (string.IsNullOrEmpty(jsonUser))
        {
            return;
        }
        else
        {
            User = JsonUtility.FromJson<User>(jsonUser);
        }
    }

    private void LoadSettingsObject()
    {
        string jsonSettings = PlayerPrefs.GetString("jsonsettings");

        if (string.IsNullOrEmpty(jsonSettings))
        {
            return;
        }
        else
        {
            Settings = JsonUtility.FromJson<Settings>(jsonSettings);
        }
    }

    public void SaveGame()
    {
        string jsonData = JsonUtility.ToJson(User);
        string jsonSettings = JsonUtility.ToJson(Settings);
        PlayerPrefs.SetString("jsonuser", jsonData);
        PlayerPrefs.SetString("jsonsettings", jsonSettings);
    }
}
