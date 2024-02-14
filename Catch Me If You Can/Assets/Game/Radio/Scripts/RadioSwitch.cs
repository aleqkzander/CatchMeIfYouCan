using UnityEngine;
using UnityEngine.UI;

public class RadioSwitch : MonoBehaviour
{
    [Header("RadioPlayerModelController")]
    public RadioPlayerModelsController RadioPlayerModelController;

    [Header("State images")]
    public Sprite RadioPlay;
    public Sprite RadioStop;

    private void Start()
    {
        if (DataManager.Instance != null)
        {
            PlayRadio(DataManager.Instance.Settings.PlayMusic);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GetComponent<Animation>().Play("OpenRadio");
        DisplayStatus(DataManager.Instance.Settings.PlayMusic);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GetComponent<Animation>().Play("CloseRadio");
    }

    public void ChangeRadioState()
    {
        if (DataManager.Instance.Settings.PlayMusic)
        {
            PlayRadio(false);
            DisplayStatus(false);
        }
        else
        {
            PlayRadio(true);
            DisplayStatus(true);
        }
    }

    private void PlayRadio(bool play)
    {
        if (play) 
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

        DataManager.Instance.Settings.PlayMusic = play;
        DataManager.Instance.SaveGame();
    }

    private void DisplayStatus(bool status)
    {
        if (status)
        {
            GetComponentInChildren<Image>().sprite = RadioPlay;

            if (RadioPlayerModelController != null) 
                RadioPlayerModelController.PlayDanceAnimation();
        }
        else
        {
            GetComponentInChildren<Image>().sprite = RadioStop;

            if (RadioPlayerModelController != null)
                RadioPlayerModelController.PlayIdleAnimation();
        }
    }
}