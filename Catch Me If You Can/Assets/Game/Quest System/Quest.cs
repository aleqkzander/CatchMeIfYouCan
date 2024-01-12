using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject TutorialSignCanvas;

    public void SetActive()
    {
        TutorialSignCanvas.SetActive(true);
        GetComponentInChildren<Animation>().Play($"Waving");
    }

    public void SetUnactive()
    {
        TutorialSignCanvas.SetActive(false);
        GetComponentInChildren<Animation>().Play($"{gameObject.name} Idle");
    }
}
