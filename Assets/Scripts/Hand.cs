using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public CardDisplay cardPrefab;
    public float CARD_SPACING;
    [SerializeField]
    private List<Card> hand = new List<Card>();
    private List<CardDisplay> handCards = new List<CardDisplay>();

    public void AddToHand(Card card)
    {
        hand.Add(card);
        CardDisplay newCard = Instantiate(cardPrefab, transform);
        newCard.card = card;
        handCards.Add(newCard);
        DisplayHand();
    }

    public void RemoveFromHand(CardDisplay card)
    {
        hand.Remove(card.card);
        handCards.Remove(card);
        DisplayHand();
    }

    private void DisplayHand()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            float transformAmount = ((float)i) - ((float)handCards.Count - 1) / 2;
            float angle = transformAmount * 3.0f;
            Vector3 position = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, 0) * CARD_SPACING;
            handCards[i].transform.localPosition = position;
        }
    }

    public bool IsEmpty()
    {
        return hand.Count == 0;
    }
}
