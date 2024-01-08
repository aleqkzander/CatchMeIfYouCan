using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ScriptableItem ScriptableItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (ScriptableItem == null) return;
        if (other.GetComponent<PlayerBuff>().IsOnCooldown()) return;

        ScriptableItem.Use(other.GetComponent<PlayerBuff>(), gameObject.GetComponent<Animation>());
    }
}
