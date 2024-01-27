using System.Collections;
using TMPro;
using UnityEngine;

public class TextPrinter : MonoBehaviour
{
    private TMP_Text _text;
    private string _fullText;
    private float printDelay = 0.015f;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _fullText = _text.text;
    }

    public void Print()
    {
        _text.text = string.Empty;
        StartCoroutine(PrintText());
    }

    private IEnumerator PrintText()
    {
        foreach (char character in _fullText)
        {
            _text.text += character;
            yield return new WaitForSeconds(printDelay);
        }
    }
}
