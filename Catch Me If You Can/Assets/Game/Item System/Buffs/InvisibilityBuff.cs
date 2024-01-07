using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invisibility Buff", menuName = "Buffs/Invisibility")]
public class InvisibilityBuff : ScriptableItem
{
    public float Duration;

    [Space(5)]
    [TextArea(3, 3)]
    public string Description;

    public override void Use(PlayerBuff playerBuff, Animation item)
    {
        playerBuff.ActivateInvisibilityBuff(Duration, Duration, item);
    }
}
