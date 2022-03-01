using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public IEnumerator DoEffect(Character character)
    {
        yield return StartCoroutine(card.effect.DoEffect(this, character));
    }
}
