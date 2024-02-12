using UnityEngine;

[CreateAssetMenu(fileName = "Invisibility Buff", menuName = "Buffs/Invisibility")]
public class InvisibilityBuff : ScriptableItem
{
    public override void ActivateItem(PlayerBuff playerBuff)
    {
        AudioSource.PlayClipAtPoint(Clip, playerBuff.gameObject.transform.position);
        playerBuff.ActivateInvisibilityBuff(Duration, Duration);
    }
}
