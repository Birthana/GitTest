using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    private Character character;
    private Stats characterStats;
    private Health characterHealth;
    private int damage;
    private Character target;

    public override void Perform(Character chara)
    {
        character = chara;
        characterStats = chara.GetComponent<Stats>();
        characterHealth = chara.GetComponent<Health>();
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        damage = characterStats.statValues[(int)Stats.Stat_Type.POW];
        yield return StartCoroutine(Targeting());
        Health health = target.GetComponent<Health>();
        Card card = character.Peep();
        Card.Trigger trigger = (card == null) ? Card.Trigger.NONE : card.trigger;
        character.Draw();
        CheckTrigger(trigger);
        health.TakeDamage(damage);
        //If enemy is blocking, discard X number of cards reduce incoming damage by X * DEF.
        Debug.Log($"Attacking {target.gameObject} for {damage} damage.");
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
            character.Draw();
        }
        else if (trigger == Card.Trigger.STAND)
        {
            //
        }
        else if (trigger == Card.Trigger.HEAL)
        {
            characterHealth.TakeDamage(-characterStats.statValues[(int)Stats.Stat_Type.MP]);
        }
    }

    IEnumerator Targeting()
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
                }
            }
            yield return null;
        }
    }
}
