using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    public override void Perform(Character chara)
    {
        PlayerCharacter character = (PlayerCharacter)chara;
        int damage = character.GetStat(Stats.POW);
        StartCoroutine(Attacking(character, damage));
    }

    IEnumerator Attacking(PlayerCharacter attackCharacter, int damage)
    {
        Debug.Log($"Target an Enemy.");
        bool still_looking = true;
        while (still_looking)
        {
            GameObject temp = Utility.WaitForMouseClick(enemyLayer, () => still_looking = false );
            if (temp != null)
            {
                Character target = temp.GetComponent<Character>();
                yield return StartCoroutine(attackCharacter.OnAttackEffects());
                DealDamage(attackCharacter, target, damage);
            }
            yield return null;
        }
    }

    private void DealDamage(PlayerCharacter attackCharacter, Character defendCharacter, int damage)
    {
        damage = CheckTrigger(attackCharacter, damage);
        defendCharacter.ChangeHealth(damage);
        Debug.Log($"Attacking {defendCharacter.gameObject} for {damage} damage.");
        attackCharacter.EndTurn();
    }

    private int CheckTrigger(PlayerCharacter attackCharacter, int damage)
    {
        Trigger trigger = attackCharacter.TriggerCheck();
        int result = trigger.Perform(attackCharacter, damage);
        return result;
    }
}
