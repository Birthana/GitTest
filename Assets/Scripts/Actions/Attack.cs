using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    private PlayerCharacter character;
    private Health characterHealth;
    private int damage;
    private Character target;

    public override void Perform(Character chara)
    {
        character = (PlayerCharacter)chara;
        characterHealth = chara.GetComponent<Health>();
        damage = character.GetStat(Stats.POW);
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        Debug.Log($"Target an Enemy.");
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, enemyLayer);
                if (hit)
                {
                    target = hit.collider.gameObject.GetComponent<Character>();
                    still_looking = false;
                    DealDamage();
                }
            }
            yield return null;
        }
    }

    private void DealDamage()
    {
        Health health = target.GetComponent<Health>();
        Card.Trigger trigger = character.TriggerCheck();
        CheckTrigger(trigger);
        health.TakeDamage(damage);
        Debug.Log($"Attacking {target.gameObject} for {damage} damage.");
        character.EndTurn();
    }

    private void CheckTrigger(Card.Trigger trigger)
    {
        if (trigger == Card.Trigger.NONE)
            return;
        if (trigger == Card.Trigger.CRIT)
        {
            damage *= 2;
        }
        else if (trigger == Card.Trigger.DRAW)
        {
            Card newCard = character.Draw();
            //Add to BS.
        }
        else if (trigger == Card.Trigger.STAND)
        {
            //
        }
        else if (trigger == Card.Trigger.HEAL)
        {
            characterHealth.TakeDamage(-character.GetStat(Stats.MP));
        }
    }
}
