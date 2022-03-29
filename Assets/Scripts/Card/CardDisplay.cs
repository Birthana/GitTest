using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public event System.Action<Card> OnCardChange;
    public TextMeshPro cardName;
    [SerializeField]
    private Card _card;

    public Card card
    {
        get 
        {
            return _card;
        }
        set 
        {
            _card = value;
            OnCardChange?.Invoke(_card);
            //DisplayCard();
        }
    }

    private void DisplayCard()
    {
        cardName.text = _card.name;
    }

    public IEnumerator DoEffect(Character character)
    {
        List<Effect> effects = card.effects;
        foreach (Effect effect in effects)
        {
            if (effect is Summon summon)
                summon.SetEffects(effects);
            yield return StartCoroutine(effect.DoEffect(this, character));
            if (effect is Summon)
                break;
        }
    }
}
