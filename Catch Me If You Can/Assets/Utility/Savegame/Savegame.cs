using UnityEngine;

public class Savegame : MonoBehaviour
{
    public static Savegame Instance { get; private set; }

    private User user;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        LoadUserInstanceOrCreateNewOne();
        DontDestroyOnLoad(this);
    }

    private void LoadUserInstanceOrCreateNewOne()
    {
        string jsonUser = PlayerPrefs.GetString("playerobject");

        if (string.IsNullOrEmpty(jsonUser))
        {
            CreateNewUser();
        }
        else
        {
            LoadUser(jsonUser);
        }
    }

    private void CreateNewUser()
    {
        user = new User();
        Debug.Log("No savedata found. Created a new User instance.");
    }

    private void LoadUser(string jsonUser)
    {
        User loadedUser = JsonUtility.FromJson<User>(jsonUser);
        user = loadedUser;
        Debug.Log("Save data found. User loaded.");
    }

    public string GetUserName()
    {
        return user.Name;
    }

    public int GetModel()
    {
        return user.Model;
    }

    public string GetLastIp()
    {
        return user.LastIp;
    }

    public void SaveUser(User user)
    {
        string jsonUser = JsonUtility.ToJson(user);
        PlayerPrefs.SetString("playerobject", jsonUser);
        Debug.Log("Saved user: " + jsonUser);
    }
}

