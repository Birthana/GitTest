using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    public Trigger trigger;
    public int MPCost;

    public Trigger GetTrigger()
    {
        return trigger;
    }

    public abstract IEnumerator DoEffect(PlayerCharacter playerCharacter);
}
