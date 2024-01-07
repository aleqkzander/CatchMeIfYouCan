using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ScriptableItem ScriptableItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (ScriptableItem != null)
        {
            PlayerBuff playerBuff = other.GetComponent<PlayerBuff>();
            ScriptableItem.Use(playerBuff, gameObject.GetComponent<Animation>());
        }
        else
        {
            Debug.LogWarning("No scriptable item assigned to the item");
        }
    }
}
