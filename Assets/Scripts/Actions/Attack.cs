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
        Card.Trigger trigger = attackCharacter.TriggerCheck();
        if (trigger == Card.Trigger.NONE)
            return damage;
        if (trigger == Card.Trigger.CRIT)
        {
            return damage *= 2;
        }
        else if (trigger == Card.Trigger.DRAW)
        {
            attackCharacter.DrawTrigger();
        }
        else if (trigger == Card.Trigger.STAND)
        {
            //
        }
        else if (trigger == Card.Trigger.HEAL)
        {
            attackCharacter.ChangeHealth(-attackCharacter.GetStat(Stats.MP));
        }
        return damage;
    }
}
