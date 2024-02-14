/*
 * Use this class to activate referenced elements for local player
 */

using Mirror;
using StarterAssets;
using UnityEngine;

public class PlayerNetworkActivator : NetworkBehaviour
{
    [SerializeField] private GameObject _playerCameras;
    [SerializeField] private GameObject _playerInterface;
    [SerializeField] private ThirdPersonController _thirdPersonController;

    private void Start()
    {
        AddPlayerStateToNetworkMatch();

        if (isLocalPlayer)
        {
            _playerCameras.SetActive(true);
            _playerInterface.SetActive(true);
            _thirdPersonController.enabled = true;
        }
    }

    private void AddPlayerStateToNetworkMatch()
    {
        NetworkMatchState networkMatchState = FindObjectOfType<NetworkMatchState>();
        if (networkMatchState == null) return;
        networkMatchState.AddPlayerState(GetComponent<PlayerState>());
    }
}
