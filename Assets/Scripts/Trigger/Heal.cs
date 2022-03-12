using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Trigger/Heal")]
public class Heal : Trigger
{
    public override int Perform(PlayerCharacter player, int damage)
    {
        player.ChangeHealth(-player.GetStat(Stats.MP));
        return damage;
    }
}
