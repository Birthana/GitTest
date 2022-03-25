using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Effect : ScriptableObject
{
    public Target target;
    public Condition condition;
    public Keyword keyword;

    public IEnumerator DoEffect(MonoBehaviour mono, Character character)
    {
        yield return mono.StartCoroutine(target.Targeting(character, CardEffect));
    }

    public abstract void CardEffect(List<Character> characters);
}