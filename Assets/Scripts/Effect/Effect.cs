using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public abstract void CardEffect(List<GameObject> characters);

    public abstract IEnumerator DoEffect(Character Character);

    public abstract string GetCardEffectDescription();
}
