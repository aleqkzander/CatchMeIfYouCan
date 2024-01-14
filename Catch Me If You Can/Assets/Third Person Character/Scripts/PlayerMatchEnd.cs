using Mirror;
using TMPro;
using UnityEngine;

public class PlayerMatchEnd : NetworkBehaviour
{
    [SerializeField] private GameObject BackToCageBtn;
    [SerializeField] private TMP_Text _winnerText;

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
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();
        }
    }

    public void Btn_BackToCage()
    {
        NetworkManager.singleton.ServerChangeScene(DataManager.Instance.CurrentLevel.Name);
    }
}
