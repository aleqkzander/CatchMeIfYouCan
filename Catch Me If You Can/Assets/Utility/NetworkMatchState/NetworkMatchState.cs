/*
 * This class get populated by the server
 */

using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMatchState : NetworkBehaviour
{
    [SerializeField] private List<PlayerState> _playerStates;
    [SerializeField] private bool _matchIsLife;
    private float _defaultMatchTime = 15f;
    private string _winnerPlayer;

    [SerializeField] private float _playerOneTime;
    [SerializeField] private float _playerTwoTime;

    private void Start()
    {
        if (isServer)
        {
            _playerStates = new();
            _playerOneTime = _defaultMatchTime;
            _playerTwoTime = _defaultMatchTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isServer)
        {
            if (!_matchIsLife) return;
            UpdatePlayerTimer();
            TrackMatchTimers();
        }
    }

    private void UpdatePlayerTimer()
    {
        if (isServer)
        {
            if (_playerStates[0].IsCaught())
            {
                _playerOneTime -= Time.deltaTime;
            }
            else
            {
                _playerTwoTime -= Time.deltaTime;
            }

            _playerStates[0].gameObject.GetComponent<PlayerInterface>().SetPlayerTime(_playerOneTime);

            if (_playerStates[1] != null)
            {
                _playerStates[1].gameObject.GetComponent<PlayerInterface>().SetPlayerTime(_playerTwoTime);
            }
        }
    }

    private void TrackMatchTimers()
    {
        if (isServer)
        {
            if (_playerOneTime <= 0 && _matchIsLife)
            {
                _matchIsLife = false;
                _winnerPlayer = _playerStates[1].GetComponent<PlayerInterface>().GetPlayerName();
                DisplayMatchEndUI();
            }
            if (_playerTwoTime <= 0 && _matchIsLife)
            {
                _matchIsLife = false;
                _winnerPlayer = _playerStates[0].GetComponent<PlayerInterface>().GetPlayerName();
                DisplayMatchEndUI();
            }
        }
    }

    private void DisplayMatchEndUI()
    {
        foreach (var player in _playerStates)
        {
            player.GetComponent<PlayerInterface>().ActivateMatchEnd(_winnerPlayer);
        }
    }

    private void SetRandomPlayerStates()
    {
        if (isServer)
        {
            // Generate a random integer (0 or 1)
            int randomNumber = Mathf.FloorToInt(Random.Range(0f, 2f));

            if (randomNumber == 0)
            {
                _playerStates[0].SetState(true);
                _playerStates[1].SetState(false);
            }

            if (randomNumber == 1)
            {
                _playerStates[0].SetState(false);
                _playerStates[1].SetState(true);
            }
        }
    }

    /// <summary>
    /// Server add the PlayerState-Component to the list when joing
    /// </summary>
    /// <param name="state"></param>
    public void AddPlayerState(PlayerState state)
    {
        _playerStates.Add(state);
    }

    /// <summary>
    /// Server use this method to change the states of the player
    /// </summary>
    public void ServerChangeStates()
    {
        if (isServer)
        {
            if (_playerStates.Count < 2 || !_matchIsLife)
            {
                return;
            }

            switch (_playerStates[0].IsCaught())
            {
                case false:
                    _playerStates[0].SetState(true);
                    _playerStates[1].SetState(false);
                    break;

                case true:
                    _playerStates[0].SetState(false);
                    _playerStates[1].SetState(true);
                    break;
            }

            foreach (var playerstate in _playerStates)
            {
                StartCoroutine(playerstate.HandleCooldown());
            }
        }
    }

    /// <summary>
    /// Will be called by GateController and start the match
    /// </summary>
    public void StartTheMatch()
    {
        if (isServer)
        {
            _matchIsLife = true;
            SetRandomPlayerStates();
        }
    }

    /// <summary>
    /// Add timeamount to player timer
    /// </summary>
    /// <param name="index"></param>
    /// <param name="timeamount"></param>
    public void AddMatchTimeToPlayer(int index, float timeamount)
    {
        if (index == 0)
        {
            _playerOneTime += timeamount;
        }
        else
        {
            _playerTwoTime += timeamount;
        }
    }
}
