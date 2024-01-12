using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private Image _statusImage;
    [SerializeField] private RawImage _faceImage;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerTime;

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
    /// Method will be called by PlayerState.cs
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
        _playerTime.text = $"{time:00} seconds";
    }

    /// <summary>
    /// Method will be called by PlayerBuff.cs
    /// </summary>
    /// <param name="color"></param>
    public void SetFaceColor(Color color)
    {
        _faceImage.color = color;
    }
}
