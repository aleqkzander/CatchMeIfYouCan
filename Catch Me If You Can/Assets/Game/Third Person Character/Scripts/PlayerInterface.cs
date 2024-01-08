using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private Image _statusImage;
    [SerializeField] private RawImage _faceImage;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerTime;

    /// <summary>
    /// Method will be called by PlayerState.cs
    /// </summary>
    /// <param name="color"></param>
    public void SetStatusColor(Color color)
    {
        _statusImage.color = color;
    }

    /// <summary>
    /// Method will be called by PlayerBuff.cs
    /// </summary>
    /// <param name="color"></param>
    public void SetFaceColor(Color color)
    {
        _faceImage.color = color;
    }

    public void SetPlayerName(string name)
    {
        _playerName.text = name;
    }


    public void SetPlayerTime(float time)
    {
        _playerTime.text = $"{time:00} seconds";
    }
}
