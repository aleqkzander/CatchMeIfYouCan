using UnityEngine;

[CreateAssetMenu(fileName = "Jump Buff", menuName = "Buffs/Jump")]
public class JumpBuff : ScriptableItem
{
    public override void ActivateItem(PlayerBuff playerBuff)
    {
        AudioSource.PlayClipAtPoint(Clip, playerBuff.gameObject.transform.position);
        playerBuff.ActivateJumpBuff(Duration, Multiplicator, Duration);
    }
}
