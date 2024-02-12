using UnityEngine;

public abstract class ScriptableItem : ScriptableObject
{
    public Sprite Sprite;
    public AudioClip Clip;
    public float Multiplicator;
    public float Duration;
    [Space(5)] [TextArea(3, 3)]
    public string Description;

    public abstract void ActivateItem(PlayerBuff playerBuff);
}
