using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats stats;
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> drop = new List<Card>();

    public void Draw()
    {
        Card temp = deck[0];
        hand.Add(temp);
        deck.RemoveAt(0);
    }
}
