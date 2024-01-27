using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialLoader : MonoBehaviour
{
    private void Start()
    {
        SetPlayerModel(DataManager.Instance.User.ModelIndex);
    }

    public void SetPlayerModel(int index)
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material = 
            DataManager.Instance.Materials[index];
    }
}
