using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableItem : ScriptableObject
{
    public string Name;

    public abstract void Use();
}
