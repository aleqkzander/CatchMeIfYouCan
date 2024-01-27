using Mirror;
using UnityEngine;

public class PlayerMaterialLoaderNetworked : NetworkBehaviour
{
    private void Start()
    {
        SetPlayerModel(DataManager.Instance.User.ModelIndex);
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
