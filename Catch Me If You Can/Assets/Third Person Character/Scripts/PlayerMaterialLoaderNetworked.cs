using Mirror;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnChangeModelId))]
    [SerializeField] private int _modelId;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (isLocalPlayer)
        {
            _modelId = DataManager.Instance.User.ModelIndex;
        }
    }

    private void OnChangeModelId(int oldValue, int newValue)
    {
        _modelId = newValue;
        SetPlayerModel(_modelId);
    }

    private void SetPlayerModel(int index)
    {
        if (isServer)
        {
            SetPlayerModelClientRpc(index);
        }
        else
        {
            if (isOwned)
            {
                SetPlayerModelCommand(index);
            }
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
        GetComponentInChildren<SkinnedMeshRenderer>().material =
            DataManager.Instance.Materials[index];
    }
}
