using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Buff", menuName = "Buffs/Speed")]
public class SpeedBuff : ScriptableItem
{
    public float Multiplicator;
    public float Duration;

    [Space(5)]
    [TextArea(3, 3)]
    public string Description;

    public override void Use(PlayerBuff playerBuff, Animation item)
    {
        playerBuff.ActivateSpeedBuff(Duration, Multiplicator, Duration, item);
    }
}
