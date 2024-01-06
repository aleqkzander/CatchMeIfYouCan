using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invisibility Buff", menuName = "Buffs/Invisibility")]
public class InvisibilityBuff : ScriptableItem
{
    public float Value;
    public float Duration;
    public float Cooldown;

    [Space(5)]
    [TextArea(3, 3)]
    public string Description;

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
