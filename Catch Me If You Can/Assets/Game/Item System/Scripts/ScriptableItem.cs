using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableItem : ScriptableObject
{
    public abstract void Use(PlayerBuff playerBuff, Animation item);
}
