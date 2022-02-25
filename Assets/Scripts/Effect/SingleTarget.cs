using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Single", menuName = "Target/Single")]
public class SingleTarget : Target
{
    public enum CharacterType { Ally, Enemy, Anyone };
    public CharacterType character;

    public override IEnumerator Targeting(Action<List<GameObject>> doEffect)
    {
        //Get LayerMask for Player & Enemy.
        LayerMask layer = 0;
        bool still_looking = true;
        while (still_looking)
        {
            GameObject hit = Utility.WaitForMouseClick(layer, () => still_looking = false);
            if (hit != null)
            {
                doEffect(new List<GameObject>() { hit });
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
