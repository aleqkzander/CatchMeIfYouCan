using Mirror;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMatchEnd : NetworkBehaviour
{
    [SerializeField] private GameObject BackToCageBtn;
    [SerializeField] private TMP_Text _winnerText;
    private bool _closeServer;

    private void Start()
    {
        if (isServer)
        {
            BackToCageBtn.SetActive(true);
        }
    }

    public void SetWinnerText(string playername)
    {
        _winnerText.text = $"{playername}\nis the winner";
    }

    public void Btn_ExitGame()
    {
        if (isServer)
        {
            _closeServer = true;
        }

        NetworkManager.singleton.StopClient();
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        if (isServer)
        {
            if (_closeServer)
            {
                NetworkManager.singleton.StopHost();
            }
        }
    }

    public void Btn_BackToCage()
    {
        NetworkManager.singleton.ServerChangeScene(DataManager.Instance.CurrentLevel.Name);
    }
}
