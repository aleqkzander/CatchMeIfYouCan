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
        GetComponent<PlayerInterface>().SetFaceColor(Color.grey);
        yield return new WaitForSecondsRealtime(time);
        _onCooldown = false;
        GetComponent<PlayerInterface>().SetFaceColor(Color.white);
    }

    public void ActivateSpeedBuff(float cooldown, float multiplicator, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleSpeedBuff(cooldown,multiplicator, abilityTime, animation));
    }
    private IEnumerator HandleSpeedBuff(float cooldown, float multiplicator, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleCooldown(cooldown));

        animation.Play("ItemShrink");
        float defaultSpeed = _thirdPersonController.MoveSpeed;
        float buffSpeed = defaultSpeed * multiplicator;
        _thirdPersonController.MoveSpeed = buffSpeed;

        yield return new WaitForSecondsRealtime(abilityTime);

        _thirdPersonController.MoveSpeed = defaultSpeed;
        animation.Play("ItemGrow");
    }


    public void ActivateInvisibilityBuff(float cooldown, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleInvisibilityBuff(cooldown, abilityTime, animation));
    }
    private IEnumerator HandleInvisibilityBuff(float cooldown, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleCooldown(cooldown));

        animation.Play("ItemShrink");
        _playerModelAnimation.Play("PlayerShrink");

        yield return new WaitForSecondsRealtime(abilityTime);

        _playerModelAnimation.Play("PlayerGrow");
        animation.Play("ItemGrow");
    }


    public void ActivateJumpBuff(float cooldown, float multiplicator, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleJumpBuff(cooldown, multiplicator, abilityTime, animation));
    }
    private IEnumerator HandleJumpBuff(float cooldown, float multiplicator, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleCooldown(cooldown));

        animation.Play("ItemShrink");
        float defaultJump = _thirdPersonController.JumpHeight;
        float buffJump = defaultJump * multiplicator;
        _thirdPersonController.JumpHeight = buffJump;

        yield return new WaitForSecondsRealtime(abilityTime);

        _thirdPersonController.JumpHeight = defaultJump;
        animation.Play("ItemGrow");
    }


    public void ActivateTimeBuff(float cooldown, float value, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleTimeBuff(cooldown, value, abilityTime, animation));
    }
    private IEnumerator HandleTimeBuff(float cooldown, float value, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleCooldown(cooldown));

        animation.Play("ItemShrink");

        // add time value to player

        yield return new WaitForSecondsRealtime(abilityTime);

        animation.Play("ItemGrow");
    }
}
