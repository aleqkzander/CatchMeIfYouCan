using UnityEngine;

public class ModelChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<SkinnedMeshRenderer>().material = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        foreach (Material material in DataManager.Instance.Materials)
        {
            if (material.mainTexture == other.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture) 
            {
                int index = DataManager.Instance.Materials.IndexOf(material);
                SetDataManagerModelIndex(index);
                ApplyPlayerMaterial(other.GetComponent<PlayerMaterialLoader>(), index);
            }
        }
    }

    private void SetDataManagerModelIndex(int index)
    {
        DataManager.Instance.User.ModelIndex = index;
        DataManager.Instance.SaveGame();
    }

    private void ApplyPlayerMaterial(PlayerMaterialLoader materialLoader, int index)
    {
        materialLoader.SetPlayerModel(index);
        Debug.Log($"Current model: {index}");
    }
}
