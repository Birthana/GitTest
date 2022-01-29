using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Character : MonoBehaviour
{
    private Stats stats;
    private List<Card> deck = new List<Card>();
    private List<Card> hand = new List<Card>();
    private List<Card> drop = new List<Card>();

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    public void Draw()
    {
        if (deck.Count == 0)
            return;
        Card temp = deck[0];
        hand.Add(temp);
        deck.RemoveAt(0);
    }
}
