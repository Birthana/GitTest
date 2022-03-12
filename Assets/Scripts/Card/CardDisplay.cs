using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
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
            DisplayCard();
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
            yield return StartCoroutine(effect.DoEffect(this, character));
        }
    }
}
