using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public LayerMask enemyLayer;

    public abstract void Perform(Character character);
}
