using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Draw", menuName = "Trigger/Draw")]
public class Draw : Trigger
{
    public override int Perform(PlayerCharacter player, int damage)
    {
        player.DrawTrigger();
        return damage;
    }
}
