using StarterAssets;
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

        // Increase movement speed when playing the tutorial scene
        PlayerActivator.GetComponent<ThirdPersonController>().MoveSpeed = 10;

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
