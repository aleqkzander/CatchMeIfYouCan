using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayCube : MonoBehaviour
{
    public Image ScenePreview;
    public TMP_Text SceneName;
    public TMP_InputField IpInput;

    private void Start()
    {
        IpInput.text = DataManager.Instance.User.LastIp;
    }

    public void Cube_StartHost()
    {
        // For debugging
        SceneManager.LoadScene(2);
    }

    public void Cube_StartClient()
    {
        if (string.IsNullOrEmpty(IpInput.text)) return;
    }
}
