using Mirror;
using System.Collections;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SerializeField] [SyncVar(hook = nameof(OnModelIdChanged))] private int _modelId;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (isLocalPlayer)
        {
            _modelId = DataManager.Instance.User.ModelIndex;
        }
    }

    private void OnModelIdChanged(int oldValue, int newValue)
    {
        Debug.Log("Applie modelid: " + newValue);
        SetPlayerModel(newValue);
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
}
