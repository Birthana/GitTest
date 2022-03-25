using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Stats))]
public abstract class Character : MonoBehaviour
{
    public event System.Action OnEndTurn;
    public event System.Action<Character> OnDeath;
    public event Action<int> OnHealthChange;
    protected Stats stats;
    [SerializeField]
    private List<Card> deck = new List<Card>();
    private List<Card> drop = new List<Card>();

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    public abstract void TakeTurn();

    public void EndTurn() => OnEndTurn();

    public void Die() => OnDeath(this);

    public void ChangeHealth(int healthChange) => OnHealthChange(healthChange);

    public int GetStat(Stats.Stat_Type stat_type)
    {
        return stats.GetStat(stat_type);
    }

    public void ChangeStat(Stats.Stat_Type stat_type, int amount)
    {
        stats.ChangeStat(stat_type, amount);
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

    public void AddCardToDeck(Card card)
    {
        deck.Add(card);
    }
}
