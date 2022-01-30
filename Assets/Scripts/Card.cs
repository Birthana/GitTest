using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum Trigger { CRIT, DRAW, STAND, HEAL, NONE }
    public Trigger trigger;
}
