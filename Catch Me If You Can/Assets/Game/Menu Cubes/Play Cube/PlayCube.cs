using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayCube : MonoBehaviour
{
    public Image previewImage;
    public TMP_Text previewText;
    public TMP_InputField ipInput;

    private void Start()
    {
        //previewText.text = DataContainer.Instance.AvaibleScenes[0].Name;
        //previewImage.sprite = DataContainer.Instance.AvaibleScenes[0].Preview;
        //ipInput.text = Savegame.Instance.Meta.LastIp;
        AssignNetworkManagerValues();
    }

    public void Cube_StartHost()
    {
        //NetworkManager.singleton.StartHost();
    }

    public void Cube_StartClient()
    {
        if (string.IsNullOrEmpty(ipInput.text)) return;
        //Savegame.Instance.Meta.LastIp = ipInput.text;
        //Savegame.Instance.SaveGame();
        //NetworkManager.singleton.networkAddress = Savegame.Instance.Meta.LastIp;
        //NetworkManager.singleton.StartClient();
    }

    private void AssignNetworkManagerValues()
    {
        //NetworkManager.singleton.onlineScene = DataContainer.Instance.AvaibleScenes[0].Name;
    }
}
