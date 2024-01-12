using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetFadeoutText : MonoBehaviour
{
    public TMP_Text Text;
    public string message = "CATCH ME IF YOU CAN";

    private void Awake()
    {
        Text.text = message;
    }
}
