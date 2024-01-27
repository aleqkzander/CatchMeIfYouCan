using UnityEngine;

public class RadioPlayer : MonoBehaviour
{
    public AudioSource AudioSource;

    private void Start()
    {
        if (AudioSource.clip == null) return;
        if (DataManager.Instance.Settings.PlayMusic == false) return;
        AudioSource.Play();
    }
}
