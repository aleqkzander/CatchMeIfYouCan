using StarterAssets;
using System.Collections;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _thirdPersonController;
    [SerializeField] private Animation _playerModelAnimation; 
    [HideInInspector] public bool _onCooldown;

    private IEnumerator HandleCooldown(float time)
    {
        _onCooldown = true;
        yield return new WaitForSecondsRealtime(time);
        _onCooldown = false;
    }

    public void ActivateSpeedBuff(float cooldown, float multiplicator, float abilityTime)
    {
        StartCoroutine(HandleSpeedBuff(cooldown,multiplicator, abilityTime));
    }
    private IEnumerator HandleSpeedBuff(float cooldown, float multiplicator, float abilityTime)
    {
        StartCoroutine(HandleCooldown(cooldown));

        float defaultSpeed = _thirdPersonController.MoveSpeed;
        float buffSpeed = defaultSpeed * multiplicator;
        _thirdPersonController.MoveSpeed = buffSpeed;

        yield return new WaitForSecondsRealtime(abilityTime);

        _thirdPersonController.MoveSpeed = defaultSpeed;
    }


    public void ActivateInvisibilityBuff(float cooldown, float abilityTime)
    {
        StartCoroutine(HandleInvisibilityBuff(cooldown, abilityTime));
    }
    private IEnumerator HandleInvisibilityBuff(float cooldown, float abilityTime)
    {
        StartCoroutine(HandleCooldown(cooldown));

        _playerModelAnimation.Play("PlayerShrink");

        yield return new WaitForSecondsRealtime(abilityTime);

        _playerModelAnimation.Play("PlayerGrow");
    }


    public void ActivateJumpBuff(float cooldown, float multiplicator, float abilityTime)
    {
        StartCoroutine(HandleJumpBuff(cooldown, multiplicator, abilityTime));
    }
    private IEnumerator HandleJumpBuff(float cooldown, float multiplicator, float abilityTime)
    {
        StartCoroutine(HandleCooldown(cooldown));

        float defaultJump = _thirdPersonController.JumpHeight;
        float buffJump = defaultJump * multiplicator;
        _thirdPersonController.JumpHeight = buffJump;

        yield return new WaitForSecondsRealtime(abilityTime);

        _thirdPersonController.JumpHeight = defaultJump;
    }


    private void ActivateTimeBuff(float cooldown, float value, float abilityTime)
    {
        StartCoroutine(HandleTimeBuff(cooldown, value, abilityTime));
    }
    private IEnumerator HandleTimeBuff(float cooldown, float value, float abilityTime)
    {
        StartCoroutine(HandleCooldown(cooldown));

        // add time value to player

        yield return new WaitForSecondsRealtime(abilityTime);
    }
}
