using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _thirdPersonController;

    [Header("Ability Display")]
    [SerializeField] private GameObject _playerModelShrink;
    [SerializeField] private List<GameObject> _speedBoostShoes;
    [SerializeField] private GameObject _angelWings;
    private bool _onCooldown;

    public bool IsOnCooldown()
    {
        return _onCooldown;
    }

    private IEnumerator HandleCooldown(float time)
    {
        _onCooldown = true;
        GetComponent<PlayerInterface>().SetFaceColor(Color.grey);
        yield return new WaitForSecondsRealtime(time);
        _onCooldown = false;
        GetComponent<PlayerInterface>().SetFaceColor(Color.white);
    }

    /// <summary>
    /// Use to activate speed buff
    /// </summary>
    /// <param name="cooldown"></param>
    /// <param name="multiplicator"></param>
    /// <param name="abilityTime"></param>
    /// <param name="animation"></param>
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

        foreach (var shoe in _speedBoostShoes)
        {
            shoe.GetComponent<Animation>().Play("ShoeGrow");
            shoe.GetComponent<TrailRenderer>().enabled = true;
        }

        yield return new WaitForSecondsRealtime(abilityTime);

        _thirdPersonController.MoveSpeed = defaultSpeed;

        foreach (var shoe in _speedBoostShoes)
        {
            shoe.GetComponent<Animation>().Play("ShoeShrink");
            shoe.GetComponent<TrailRenderer>().enabled = false;
        }

        animation.Play("ItemGrow");
    }

    /// <summary>
    /// Use to activate invisibility
    /// </summary>
    /// <param name="cooldown"></param>
    /// <param name="abilityTime"></param>
    /// <param name="animation"></param>
    public void ActivateInvisibilityBuff(float cooldown, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleInvisibilityBuff(cooldown, abilityTime, animation));
    }

    private IEnumerator HandleInvisibilityBuff(float cooldown, float abilityTime, Animation animation)
    {
        StartCoroutine(HandleCooldown(cooldown));

        animation.Play("ItemShrink");
        _playerModelShrink.GetComponent<Animation>().Play("PlayerShrink");

        yield return new WaitForSecondsRealtime(abilityTime);

        _playerModelShrink.GetComponent<Animation>().Play("PlayerGrow");
        animation.Play("ItemGrow");
    }

    /// <summary>
    /// Use to activate the jump buff
    /// </summary>
    /// <param name="cooldown"></param>
    /// <param name="multiplicator"></param>
    /// <param name="abilityTime"></param>
    /// <param name="animation"></param>
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
        _angelWings.GetComponent<Animation>().Play("WingsGrow");

                yield return new WaitForSecondsRealtime(abilityTime);

        _thirdPersonController.JumpHeight = defaultJump;
        _angelWings.GetComponent<Animation>().Play("WingsShrink");
        animation.Play("ItemGrow");
    }

    /// <summary>
    /// Use to activate the timebuff - currently under development
    /// </summary>
    /// <param name="cooldown"></param>
    /// <param name="value"></param>
    /// <param name="abilityTime"></param>
    /// <param name="animation"></param>
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
