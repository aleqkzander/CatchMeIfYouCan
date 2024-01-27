using UnityEngine;

[CreateAssetMenu(fileName = "Jump Buff", menuName = "Buffs/Jump")]
public class JumpBuff : ScriptableItem
{
    public float Multiplicator;
    public float Duration;
    public AudioClip PickupAudio;

    [Space(5)]
    [TextArea(3, 3)]
    public string Description;

    public override void Use(PlayerBuff playerBuff, Animation item)
    {
        AudioSource.PlayClipAtPoint(PickupAudio, playerBuff.gameObject.transform.position);
        playerBuff.ActivateJumpBuff(Duration, Multiplicator, Duration, item);
    }
}
