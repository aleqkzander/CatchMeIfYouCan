using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInterface : NetworkBehaviour
{
    [SerializeField] private Image _statusImage;
    [SerializeField] private RawImage _faceImage;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerTime;
    [SerializeField] private GameObject _matchEnd;

    private void Start()
    {
        SetPlayerName(DataManager.Instance.User.Name);
    }

    private void SetPlayerName(string name)
    {
        /*
         * Player can setup his name by his own
         * Server later can access this by accessing the text of the _playerName text element
         */

        _playerName.text = name;
    }

    /// <summary>
    /// Use method to get the playername
    /// </summary>
    /// <returns></returns>
    public string GetPlayerName()
    {
        return _playerName.text;
    }

    /// <summary>
    /// Method will be called and replicated by PlayerState.cs
    /// </summary>
    /// <param name="color"></param>
    public void SetStatusColor(Color color)
    {
        _statusImage.color = color;
    }

    /// <summary>
    /// Method will be called by NetworkMatchState.cs
    /// </summary>
    /// <param name="time"></param>
    public void SetPlayerTime(float time)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            _playerTime.text = $"{time:00} seconds";
        }
        else
        {
            if (isServer)
            {
                SetPlayerTimeClientRpc(time);
            }
            else
            {
                if (isOwned)
                {
                    SetPlayerTimeCommand(time);
                }
            }
        }
    }

    /// <summary>
    /// Method will be called by PlayerBuff.cs
    /// </summary>
    /// <param name="color"></param>
    public void SetFaceColor(Color color)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            _faceImage.color = color;
        }
        else
        {
            if (isServer)
            {
                SetFaceColorClientRpc(color);
            }
            else
            {
                if (isOwned)
                {
                    SetFaceColorCommand(color);
                }
            }
        }
    }

    /// <summary>
    /// Method will be called by NetworkMatchState.cs
    /// </summary>
    public void ActivateMatchEnd(string winnerName)
    {
        if (isServer)
        {
            ActivateMatchEndClientRpc(winnerName);
        }
        else
        {
            ActivateMatchEndCommand(winnerName);
        }
    }

    [Command]
    private void ActivateMatchEndCommand(string winnerName)
    {
        ActivateMatchEndClientRpc(winnerName);
    }

    [ClientRpc]
    private void ActivateMatchEndClientRpc(string winnerName)
    {
        DataManager.Instance.Movement.Disable();
        _matchEnd.SetActive(true);
        _matchEnd.GetComponent<PlayerMatchEnd>().SetWinnerText(winnerName);
    }

    [Command]
    private void SetPlayerTimeCommand(float time)
    {
        SetPlayerTimeClientRpc(time);
    }

    [Command]
    private void SetFaceColorCommand(Color color)
    {
        SetFaceColorClientRpc(color);
    }

    [ClientRpc]
    private void SetPlayerTimeClientRpc(float time)
    {
        _playerTime.text = $"{time:00} seconds";
    }

    [ClientRpc]
    private void SetFaceColorClientRpc(Color color)
    {
        _faceImage.color = color;
    }
}
