using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (isLocalPlayer)
        {
            SetPlayerModel(DataManager.Instance.User.ModelIndex);
        }
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
            _materials[index];
    }
}
