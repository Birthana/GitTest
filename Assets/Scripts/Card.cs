using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Trigger { CRIT, DRAW, STAND, HEAL, NONE };
    private Trigger trigger;
    private Character owner;

    public void SetOwner(Character character)
    {
        owner = character;
    }

    public Trigger GetTrigger()
    {
        return trigger;
    }
}
