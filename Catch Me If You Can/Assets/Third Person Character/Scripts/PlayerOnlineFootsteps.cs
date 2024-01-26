using Mirror;
using UnityEngine;

public class PlayerOnlineFootsteps : NetworkBehaviour
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
                if (isOwned) PlayFootStepsCommand(index);
            }
        }
    }

    [Command]
    private void PlayFootStepsCommand(int index)
    {
        PlayFootStepsClientRpc(index);
    }

    [ClientRpc]
    private void PlayFootStepsClientRpc(int index)
    {
        AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
    }
}
