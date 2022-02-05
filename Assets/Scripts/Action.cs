using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    protected Character owner;

    public abstract IEnumerator Perform();

    public void SetOwner(Character character)
    {
        owner = character;
    }
}
