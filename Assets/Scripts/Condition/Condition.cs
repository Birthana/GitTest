using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Condition : ScriptableObject
{
    public abstract bool CheckCondition(Character character);
}
