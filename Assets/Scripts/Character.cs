using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private List<Card> deck = new List<Card>();
    [SerializeField]
    private List<Card> drop = new List<Card>();

    public abstract void TakeTurn();

    public Card Draw()
    {
        //Check if empty.
        Card result = deck[0];
        deck.RemoveAt(0);
        return result;
    }

    public void Add(Card newCard)
    {
        newCard.SetOwner(this);
        deck.Add(newCard);
    }

    public void SendToDrop(Card dropCard)
    {
        drop.Add(dropCard);
    }
}
