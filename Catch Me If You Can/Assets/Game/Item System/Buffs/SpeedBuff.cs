using UnityEngine;

[CreateAssetMenu(fileName = "Speed Buff", menuName = "Buffs/Speed")]
public class SpeedBuff : ScriptableItem
{
    public override void ActivateItem(PlayerBuff playerBuff)
    {
        AudioSource.PlayClipAtPoint(Clip, playerBuff.gameObject.transform.position);
        playerBuff.ActivateSpeedBuff(Duration, Multiplicator, Duration);
    }
}
