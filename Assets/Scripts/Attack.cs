using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    private Stats stats;
    private int damage;

    public override void Perform()
    {
        BattleSystem bs = FindObjectOfType<BattleSystem>();
        stats = owner.GetComponent<Stats>();
        Card.Trigger trigger = bs.TriggerCheck(owner);
        if (trigger == Card.Trigger.NONE)
            damage = stats.GetStat(Stats.Stat_Type.POW);
        //Choose Target & Deal Damage.
    }
}
