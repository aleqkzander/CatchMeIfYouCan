using Mirror;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnModelIdChanged))] [SerializeField] private int _modelId;
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
        if (isServer)
        {
            SetPlayerModelClientRpc(newValue);
        }
    }

    private void SetPlayerModel(int index)
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material =
            DataManager.Instance.Materials[index];
    }


    [Command]
    private void SetPlayerModelCommand(int index)
    {
        SetPlayerModelClientRpc(index);
    }

    [ClientRpc]
    private void SetPlayerModelClientRpc(int index)
    {
        _skinnedMeshRenderer.material = DataManager.Instance.Materials[index];
    }
}
