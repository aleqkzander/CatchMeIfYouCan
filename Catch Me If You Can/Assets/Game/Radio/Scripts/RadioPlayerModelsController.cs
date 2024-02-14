using System.Collections.Generic;
using UnityEngine;

public class RadioPlayerModelsController : MonoBehaviour
{
    public List<Animation> ModelAnimations;

    private void Start()
    {
        if (ModelAnimations.Count == 0) return;

        if (DataManager.Instance != null)
        {
            if (DataManager.Instance.Settings.PlayMusic)
            {
                PlayDanceAnimation();
            }
            else
            {
                PlayIdleAnimation();
            }
        }
    }

    public void PlayIdleAnimation()
    {
        foreach (var animation in ModelAnimations)
        {
            if (animation != null)
                animation.Play(animation.gameObject.name + " Idle");
        }
    }

    public void PlayDanceAnimation()
    {
        foreach (var animation in ModelAnimations)
        {
            if (animation != null)
                animation.Play(animation.gameObject.name + " Dance");
        }
    }
}
