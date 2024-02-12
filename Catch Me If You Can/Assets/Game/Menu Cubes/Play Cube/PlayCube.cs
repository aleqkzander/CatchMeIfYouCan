using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayCube : MonoBehaviour
{
    public Image ScenePreview;
    public TMP_Text HostGameTxt;
    public TMP_Text SceneName;
    public TMP_InputField IpInput;
    private int currentScene = 0;

    private void Start()
    {
        IpInput.text = DataManager.Instance.Settings.LastIp;
        DisplayCurrentLevel(currentScene);
    }

    private void DisplayCurrentLevel(int index)
    {
        DataManager.Instance.CurrentLevel = DataManager.Instance.Levels[index];
        NetworkManager.singleton.onlineScene = DataManager.Instance.CurrentLevel.Name;
        SceneName.text = DataManager.Instance.CurrentLevel.Name;
        ScenePreview.sprite = DataManager.Instance.CurrentLevel.Sprite;
    }

    public void Cube_SelectNextScene()
    {
        int maxScenes = DataManager.Instance.Levels.Count;

        if (currentScene < maxScenes - 1)
        {
            HostGameTxt.text = "HOST GAME";
            currentScene++;
        }
        else
        {
            HostGameTxt.text = "PLAY TUTORIAL";
            currentScene = 0;
        }

        DisplayCurrentLevel(currentScene);
    }

    public void Cube_StartHost()
    {
        if (currentScene == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            NetworkManager.singleton.StartHost();
        }
    }

    public void Cube_StartClient()
    {
        if (string.IsNullOrEmpty(IpInput.text)) return;
        DataManager.Instance.Settings.LastIp = IpInput.text;
        DataManager.Instance.SaveGame();

        NetworkManager.singleton.networkAddress = IpInput.text;
        NetworkManager.singleton.StartClient();
    }
}
