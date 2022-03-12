using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Single", menuName = "Target/Single")]
public class SingleTarget : Target
{
    public enum CharacterType { Ally = 3, Enemy = 6, Anyone };
    public CharacterType character;

    public override IEnumerator Targeting(Character self, Action<List<Character>> doEffect)
    {
        Debug.Log("Targeting...");
        int layer = (int)character;
        bool still_looking = true;
        while (still_looking)
        {
            GameObject hit = Utility.WaitForMouseClick(1 << layer, () => still_looking = false);
            if (hit != null)
            {
                doEffect(new List<Character>() { hit.GetComponent<Character>() });
            }
            yield return null;
        }
    }

    public override string GetCardDescription()
    {
        string result = (character == CharacterType.Anyone) ? $"Target Ally or Enemy " : $"Target {character} " ;
        return result;
    }
}
