using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Engage", menuName = "Keyword/Engage")]
public class Engage : Keyword
{
    public override void AddToEvent(Func<MonoBehaviour, Character, IEnumerator> effect, Character character)
    {
        PlayerCharacter newChara = (PlayerCharacter)character;
        newChara.OnAttack += effect;
        Debug.Log($"Add this Keyword: {this} effect to {newChara}");
    }
}
