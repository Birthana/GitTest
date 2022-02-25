using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : Effect
{
    public int damage;
    public Target target;

    public override void CardEffect(List<GameObject> characters)
    {
        foreach (GameObject character in characters)
        {
            Character target = character.GetComponent<Character>();
            target.ChangeHealth(damage);
        }
    }

    public override IEnumerator DoEffect(Character character)
    {
        yield return StartCoroutine(target.Targeting(CardEffect));
    }

    public override string GetCardEffectDescription()
    {
        return $"{target.GetCardDescription()} is dealt {damage} damage.";
    }
}
