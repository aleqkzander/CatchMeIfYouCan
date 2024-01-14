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
        if (isLocalPlayer)
        {
            _playerCameras.SetActive(true);
            _playerInterface.SetActive(true);
            _thirdPersonController.enabled = true;
            AddPlayerStateToNetworkMatch();
        }
    }

    private void AddPlayerStateToNetworkMatch()
    {
        /*
         * Don't need to check for server because NetworkMatchState.cs is doing the check
         */

        FindObjectOfType<NetworkMatchState>().AddPlayerState(GetComponent<PlayerState>());
    }
}
