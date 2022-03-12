using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Target : ScriptableObject
{
    public abstract IEnumerator Targeting(Character self, System.Action<List<Character>> doEffect);

    public abstract string GetCardDescription();
}
