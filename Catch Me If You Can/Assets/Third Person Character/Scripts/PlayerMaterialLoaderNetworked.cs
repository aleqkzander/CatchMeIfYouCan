using Mirror;
using Mono.CecilX.Cil;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SerializeField] private int _materalId;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    public override void OnStartClient()
    {
        base.OnStartClient();
        _materalId = DataManager.Instance.User.ModelIndex;

        if (isServer)
        {
            PlayerMaterialLoaderNetworked[] playerMaterialLoadersNetworked = FindObjectsOfType<PlayerMaterialLoaderNetworked>();
            foreach (var loader in playerMaterialLoadersNetworked)
            {
                loader.SetPlayerModel();
            }
        }
    }

    public void SetPlayerModel()
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
