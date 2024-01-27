using UnityEngine;

[CreateAssetMenu(fileName = "Invisibility Buff", menuName = "Buffs/Invisibility")]
public class InvisibilityBuff : ScriptableItem
{
    public float Duration;
    public AudioClip PickupAudio;

    [Space(5)]
    [TextArea(3, 3)]
    public string Description;

    public override void Use(PlayerBuff playerBuff, Animation item)
    {
        AudioSource.PlayClipAtPoint(PickupAudio, playerBuff.gameObject.transform.position);
        playerBuff.ActivateInvisibilityBuff(Duration, Duration, item);
    }
}
