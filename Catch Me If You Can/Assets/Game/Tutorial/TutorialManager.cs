using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> TutorialObject;
    public int CurrentTutorial;

    private void Awake()
    {
        Tutorial[] tutorialObjects = FindObjectsOfType<Tutorial>();
        foreach (var tutorial in tutorialObjects)
        {
            TutorialObject.Add(tutorial);
        }
        TutorialObject.Reverse();
    }

    private void Start()
    {
        RemoveAllSigns();
        ActivateSignForCurrentTutorial();
    }

    public void RemoveAllSigns()
    {
        foreach (var tutorial in TutorialObject)
        {
            tutorial.SetTutorialSignCanvas(false);
        }
    }

    public void ActivateSignForCurrentTutorial()
    {
       TutorialObject[CurrentTutorial].GetComponent<Tutorial>().SetTutorialSignCanvas(true);
    }
}
