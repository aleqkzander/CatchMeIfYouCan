using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject PlayerActivator;
    public List<Tutorial> TutorialObject;
    public int CurrentTutorial;

    private void Start()
    {
        PlayerActivator.SetActive(true);
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
