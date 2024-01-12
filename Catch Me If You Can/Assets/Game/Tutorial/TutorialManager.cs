using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> TutorialObject;
    public int CurrentTutorial;

    private void Start()
    {
        RemoveAllSigns();
        ActivateSignForCurrentTutorial();
    }

    public void RemoveAllSigns()
    {
        foreach (var tutorial in TutorialObject)
        {
            tutorial.SetUnactive();
        }
    }

    public void ActivateSignForCurrentTutorial()
    {
       TutorialObject[CurrentTutorial].GetComponent<Tutorial>().SetActive();
    }
}
