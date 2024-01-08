using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialSignCanvas;
    public GameObject TutorialTextCanvas;
    public GameObject Player;
    private TutorialManager _tutorialManager;

    private void Awake()
    {
        _tutorialManager = FindAnyObjectByType<TutorialManager>();
    }

    private void Update()
    {
        transform.LookAt(
            new Vector3(Player.transform.position.x, 0, Player.transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TutorialSignCanvas.activeSelf)
        {
            _tutorialManager.CurrentTutorial++;
        }

        TutorialTextCanvas.SetActive(true);
        GetComponentInChildren<TextPrinter>().Print();
        GetComponentInChildren<Animation>().Play($"Talking");
    }

    private void OnTriggerExit(Collider other)
    {
        _tutorialManager.RemoveAllSigns();

        if (_tutorialManager.CurrentTutorial < _tutorialManager.TutorialObject.Count)
        {
            _tutorialManager.ActivateSignForCurrentTutorial();
        }

        TutorialTextCanvas.SetActive(false);
        SetUnactive();
    }

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
