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

    private void OnTriggerEnter(Collider other)
    {
        OpenCube();
    }

    private void OpenCube()
    {
        GetComponent<Animation>().Play("CubeShow");
        GetComponent<InterfaceController>().EnableMouse();
    }

    public void Cube_CloseCube()
    {
        GetComponent<Animation>().Play("CubeHide");
        GetComponent<InterfaceController>().DisableMouse();
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
