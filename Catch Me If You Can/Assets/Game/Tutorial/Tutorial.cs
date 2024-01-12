using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialSignCanvas;
    public GameObject TutorialTextCanvas;
    private GameObject _player;
    private TutorialManager _tutorialManager;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _tutorialManager = FindAnyObjectByType<TutorialManager>();
    }

    private void Update()
    {
        transform.LookAt(
            new Vector3(_player.transform.position.x, 0, _player.transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TutorialSignCanvas.activeSelf)
        {
            _tutorialManager.CurrentTutorial++;
        }

        _tutorialManager.RemoveAllSigns();

        if (_tutorialManager.CurrentTutorial < _tutorialManager.TutorialObject.Count)
        {
            _tutorialManager.ActivateSignForCurrentTutorial();
        }

        PlayerTalk();
    }

    private void OnTriggerExit(Collider other)
    {
        TutorialTextCanvas.SetActive(false);
        GetComponentInChildren<Animation>().Play($"{gameObject.name} Idle");
    }

    private  void PlayerTalk()
    {
        TutorialSignCanvas.SetActive(false);
        TutorialTextCanvas.SetActive(true);
        GetComponentInChildren<TextPrinter>().Print();
        GetComponentInChildren<Animation>().Play($"Talking");
    }

    /// <summary>
    /// Use on tutorial manager
    /// </summary>
    public void SetActive()
    {
        TutorialSignCanvas.SetActive(true);
        GetComponentInChildren<Animation>().Play($"Waving");
    }

    /// <summary>
    /// Use on tutorial manager
    /// </summary>
    public void SetUnactive()
    {
        TutorialSignCanvas.SetActive(false);
        GetComponentInChildren<Animation>().Play($"{gameObject.name} Idle");
    }
}
