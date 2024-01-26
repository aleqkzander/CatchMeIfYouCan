using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayCube : MonoBehaviour
{
    public Image ScenePreview;
    public TMP_Text SceneName;
    public TMP_InputField IpInput;
    private int currentScene = 1;

    private void Start()
    {
        IpInput.text = DataManager.Instance.User.LastIp;
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
            currentScene++;
        }
        else
        {
            // keep currentScene 1 to exclude the Playground scene
            currentScene = 1;
        }

        DisplayCurrentLevel(currentScene);
    }

    public void Cube_StartHost()
    {
        NetworkManager.singleton.StartHost();
    }

    public void Cube_StartClient()
    {
        if (string.IsNullOrEmpty(IpInput.text)) return;
        NetworkManager.singleton.networkAddress = IpInput.text;
        NetworkManager.singleton.StartClient();
    }
}
