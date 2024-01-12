using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Time Buff", menuName = "Buffs/Time")]
public class TimeBuff : ScriptableItem
{
    public float Time;
    public float Duration;

    [Space(5)]
    [TextArea(3,3)]
    public string Description;

    public override void Use(PlayerBuff playerBuff, Animation item)
    {
        playerBuff.ActivateSpeedBuff(Duration, Time, Duration, item);
    }
}
