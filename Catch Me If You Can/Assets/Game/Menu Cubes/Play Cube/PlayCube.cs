using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayCube : MonoBehaviour
{
    public Image ScenePreview;
    public TMP_Text SceneName;
    public TMP_InputField IpInput;

    private void Start()
    {
        IpInput.text = DataManager.Instance.User.LastIp;
        SelectCurrentLevel(0);
    }

    private void SelectCurrentLevel(int index)
    {
        DataManager.Instance.CurrentLevel = DataManager.Instance.Levels[index];
        NetworkManager.singleton.onlineScene = DataManager.Instance.CurrentLevel.Name;
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
