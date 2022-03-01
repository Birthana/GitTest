using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DealDamage", menuName = "Effect/DealDamage")]
public class DealDamage : Effect
{
    public int damage;
    public Target target;

    public override void CardEffect(List<Character> characters)
    {
        foreach (Character character in characters)
        {
            Debug.Log($"Dealing {damage} to {character}.");
            character.ChangeHealth(damage);
        }
    }

    //Start this Coroutine to start card effect.
    public override IEnumerator DoEffect(MonoBehaviour mono,Character character)
    {
        yield return mono.StartCoroutine(target.Targeting(character, CardEffect));
    }

    public override string GetCardEffectDescription()
    {
        return $"{target.GetCardDescription()} is dealt {damage} damage.";
    }
}
