using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Keyword : ScriptableObject
{
    public abstract void AddToEvent(Func<MonoBehaviour, Character, IEnumerator> effect, Character character);
}
