using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Critical", menuName = "Trigger/Critical")]
public class Critical : Trigger
{
    public override int Perform(PlayerCharacter player, int damage)
    {
        return damage *= 2;
    }
}
