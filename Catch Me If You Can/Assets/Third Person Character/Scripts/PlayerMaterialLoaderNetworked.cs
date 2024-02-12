using Mirror;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnChangeModelId))]
    [SerializeField] private int _modelId;

    private void Start()
    {
        _modelId = DataManager.Instance.User.ModelIndex;
        Invoke(nameof(SetPlayerModel), 0.5f);
    }

    private void OnChangeModelId(int oldValue, int newValue)
    {
        SetPlayerModel(newValue);
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
