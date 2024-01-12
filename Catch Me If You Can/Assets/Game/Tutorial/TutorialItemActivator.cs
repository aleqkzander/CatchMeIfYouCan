using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemActivator : MonoBehaviour
{
    public GameObject Item;

    private void Awake()
    {
        Item.SetActive(true);
    }
}
