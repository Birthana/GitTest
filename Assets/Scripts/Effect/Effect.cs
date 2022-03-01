using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract void CardEffect(List<Character> characters);

    public abstract IEnumerator DoEffect(MonoBehaviour mono, Character Character);

    public abstract string GetCardEffectDescription();
}
