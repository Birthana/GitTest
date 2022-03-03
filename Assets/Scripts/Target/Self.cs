using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Self", menuName = "Target/Self")]
public class Self : Target
{
    public override IEnumerator Targeting(Character self, Action<List<Character>> doEffect)
    {
        Debug.Log($"Drawing... ");
        doEffect(new List<Character>() { self });
        yield return null;
    }

    public override string GetCardDescription()
    {
        return $"";
    }
}
