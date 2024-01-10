using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public User User;
    public List<Level> Levels;
    public Movement Movement;
    public Mouse Mouse;

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
        }
    }

    private void LoadUserObject()
    {
        string jsonUser = PlayerPrefs.GetString("jsonuser");

        if (string.IsNullOrEmpty(jsonUser))
        {
            Debug.Log("No savedata was found.");
            return;
        }
        else
        {
            Debug.Log("Savedata was loaded successfully: " + jsonUser);
            User = JsonUtility.FromJson<User>(jsonUser);
        }
    }

    public void SaveGame()
    {
        string jsonData = JsonUtility.ToJson(User);
        PlayerPrefs.SetString("jsonuser", jsonData);
    }
}
