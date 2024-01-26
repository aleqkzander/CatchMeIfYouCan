using Mirror;
using UnityEngine;

public class PlayerOfflineFootsteps : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] AudioClip[] FootstepAudioClips;
    [Range(0, 1)][SerializeField] float FootstepAudioVolume = 0.5f;

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
        }
    }
}
