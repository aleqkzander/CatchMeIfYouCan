using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialSignCanvas;
    public GameObject TutorialTextCanvas;
    private TutorialManager _tutorialManager;

    private void Awake()
    {
        _tutorialManager = FindAnyObjectByType<TutorialManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TutorialSignCanvas.activeSelf)
        {
            _tutorialManager.CurrentTutorial++;
        }

        TutorialTextCanvas.SetActive(true);
        GetComponentInChildren<TextPrinter>().Print();
    }

    private void OnTriggerExit(Collider other)
    {
        _tutorialManager.RemoveAllSigns();

        if (_tutorialManager.CurrentTutorial < _tutorialManager.TutorialObject.Count)
        {
            _tutorialManager.ActivateSignForCurrentTutorial();
        }

        TutorialTextCanvas.SetActive(false);
    }

    public void SetTutorialSignCanvas(bool state)
    {
        TutorialSignCanvas.SetActive(state);
    }
}
