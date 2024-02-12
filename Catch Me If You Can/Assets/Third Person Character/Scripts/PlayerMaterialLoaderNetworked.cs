using Mirror;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SerializeField] [SyncVar] private int _materalId;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (isLocalPlayer)
        {
            _materalId = DataManager.Instance.User.ModelIndex;
        }

        PlayerMaterialLoaderNetworked[] playerMaterialLoadersNetworked = FindObjectsOfType<PlayerMaterialLoaderNetworked>();
        foreach (var loader in playerMaterialLoadersNetworked)
        {
            loader.SetPlayerModel(loader.GetModleId());
        }
    }

    public int GetModleId()
    {
        return _materalId;
    }

    public void SetPlayerModel(int index)
    {
        if (isServer)
        {
            SetPlayerModelClientRpc(_materalId);
        }
        else if (isOwned)
        {
            SetPlayerModelCommand(_materalId);
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
}
