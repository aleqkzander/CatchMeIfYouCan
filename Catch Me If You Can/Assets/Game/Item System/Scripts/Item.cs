using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ScriptableItem ScriptableItem;

    private void Awake()
    {
        if (ScriptableItem != null)
        {
            gameObject.name = ScriptableItem.Name;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ScriptableItem != null)
        {
            ScriptableItem.Use();
        }
    }
}
