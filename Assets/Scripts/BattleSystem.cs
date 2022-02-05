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

    private void Start()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        Debug.Log($"{turnOrder[currentIndex].name}'s turn.");
        turnOrder[currentIndex].TakeTurn();
        currentIndex++;
    }

    public Card.Trigger TriggerCheck(Character character)
    {
        Card.Trigger result = Card.Trigger.NONE;
        Card triggerCheck = character.Draw();
        if(triggerCheck != null)
            result = triggerCheck.GetTrigger();
        hand.Add(triggerCheck);
        return result;
    }
}
