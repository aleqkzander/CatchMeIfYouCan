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
        LoadTheLastIp();
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenCube();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseCube();
    }

    private void OpenCube()
    {
        GetComponent<Animation>().Play("CubeShow");
        DataManager.Instance.Mouse.Enable();
    }

    private void CloseCube()
    {
        GetComponent<Animation>().Play("CubeHide");
        DataManager.Instance.Mouse.Disable();
    }

    private void LoadTheLastIp()
    {
        string savedIP = DataManager.Instance.User.LastIp;

        if (string.IsNullOrEmpty(savedIP))
        {
            IpInput.text = "127.0.0.1";
        }
        else
        {
            IpInput.text = savedIP;
        }
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
