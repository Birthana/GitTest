using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public abstract class Character : MonoBehaviour
{
    public event System.Action OnEndTurn;
    protected Stats stats;
    private List<Card> deck = new List<Card>();
    private List<Card> drop = new List<Card>();

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    public abstract void TakeTurn();

    public void EndTurn() => OnEndTurn();

    public int GetStat(Stats.Stat_Type stat_type)
    {
        return stats.GetStat(stat_type);
    }

    public Card Peep()
    {
        //If deck empty reShuffle drop to deck. if drop is empty. it shouldnt.
        if (deck.Count == 0)
            return null;
        return deck[0];
    }

    public Card Draw()
    {
        if (deck.Count == 0)
            return null;
        Card temp = deck[0];
        deck.RemoveAt(0);
        return temp;
    }
}
