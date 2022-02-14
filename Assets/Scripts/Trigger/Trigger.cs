using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : ScriptableObject
{
    public abstract int Perform(PlayerCharacter player, int damage);
}
