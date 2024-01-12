/*
 * Use this class to activate referenced elements for local player
 */

using UnityEngine;

public class PlayerNetworkActivator : MonoBehaviour
{
    [SerializeField] private GameObject _playerCameras;
    [SerializeField] private GameObject _playerInterface;

    private void Start()
    {
        // make local player check
        _playerCameras.SetActive(true);
        _playerInterface.SetActive(true);
        AddPlayerStateToNetworkMatch();
    }

    private void AddPlayerStateToNetworkMatch()
    {

    }
}
