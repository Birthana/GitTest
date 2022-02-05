using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    public LayerMask enemyLayer;
    private Stats stats;
    private int damage;

    public override IEnumerator Perform()
    {
        Debug.Log($"Choose an Enemy to Attack.");
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, enemyLayer);
                if (hit)
                {
                    still_looking = false;
                    DealDamage(hit.collider.GetComponent<Health>());
                }
            }
            yield return null;
        }
    }

    private void DealDamage(Health health)
    {
        BattleSystem bs = FindObjectOfType<BattleSystem>();
        stats = owner.GetComponent<Stats>();
        Card.Trigger trigger = bs.TriggerCheck(owner);
        damage = stats.GetStat(Stats.Stat_Type.POW) - 
            (health.gameObject.GetComponent<Stats>().GetStat(Stats.Stat_Type.DEF) / 2);
        Debug.Log($"Dealt {damage} damage to {health.gameObject.name}");
        health.ChangeHealth(damage);
    }
}
