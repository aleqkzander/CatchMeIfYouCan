using Mirror;
using System.Collections;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
     [SerializeField] private int _modelId;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (isLocalPlayer)
        {
            _modelId = DataManager.Instance.User.ModelIndex;
            SetPlayerModel(_modelId);
        }
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        RpcSetHostPlayerModel(_modelId);
    }


    private void SetPlayerModel(int index)
    {
        if (isServer)
        {
            SetPlayerModelClientRpc(index);
        }
        else if (isOwned)
        {
            SetPlayerModelCommand(index);
        }
    }

    [Command]
    private void SetPlayerModelCommand(int index)
    {
        SetPlayerModelClientRpc(index);
    }

    [ClientRpc]
    private void SetPlayerModelClientRpc(int index)
    {
        _skinnedMeshRenderer.material = 
            DataManager.Instance.Materials[index];
    }

    [ClientRpc]
    private void RpcSetHostPlayerModel(int index)
    {
        // Synchronize host player's material with new clients
        if (!isLocalPlayer && isServer)
        {
            _skinnedMeshRenderer.material = 
                DataManager.Instance.Materials[index];
        }
    }
}
