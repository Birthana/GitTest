using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : ScriptableObject
{
    public abstract IEnumerator Targeting(System.Action<List<GameObject>> doEffect);

    public abstract string GetCardDescription();
}
