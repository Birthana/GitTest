using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private Character[] turnOrder;
    [SerializeField]
    private List<Card> hand = new List<Card>();
    private int currentIndex = 0;

    public void NextTurn()
    {
        turnOrder[currentIndex].TakeTurn();
        currentIndex++;
    }

    public Card.Trigger TriggerCheck(Character character)
    {
        Card.Trigger result = Card.Trigger.NONE;
        Card triggerCheck = character.Draw();
        result = triggerCheck.GetTrigger();
        hand.Add(triggerCheck);
        return result;
    }
}
