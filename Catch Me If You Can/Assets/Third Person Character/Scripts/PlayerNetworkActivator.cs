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
    [SerializeField] private PlayerMaterialLoaderNetworked _playerMaterialLoaderNetworked;

    private void Start()
    {
        AddPlayerStateToNetworkMatch();

        if (isLocalPlayer)
        {
            _playerCameras.SetActive(true);
            _playerInterface.SetActive(true);
            _thirdPersonController.enabled = true;
            //_playerMaterialLoaderNetworked.enabled = true;
        }
    }

    private void AddPlayerStateToNetworkMatch()
    {
        FindObjectOfType<NetworkMatchState>().AddPlayerState(GetComponent<PlayerState>());
    }
}
