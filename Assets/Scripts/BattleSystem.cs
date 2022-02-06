using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleSystem : MonoBehaviour
{
    public Character[] turnOrder;
    private int currentIndex = 0;
    private List<Card> hand = new List<Card>();

    private void Start()
    {
        TakeTurn(turnOrder[0]);
    }

    private void TakeTurn(Character character)
    {
        Debug.Log($"{character.gameObject.name}'s Turn.");
        if(character is PlayerCharacter)
            hand.Add(character.Draw());
        character.TakeTurn();
    }

    public Card.Trigger TriggerCheck(Character character)
    {
        Card.Trigger result = Card.Trigger.NONE;
        Card triggerCheck = character.Draw();
        if (triggerCheck != null)
            result = triggerCheck.trigger;
        hand.Add(triggerCheck);
        return result;
    }

    public void NextTurn()
    {
        if (CheckIfCombatDone())
            return;
        currentIndex++;
        if (currentIndex >= turnOrder.Length)
            currentIndex = 0;
        TakeTurn(turnOrder[currentIndex]);
    }

    private bool CheckIfCombatDone()
    {
        bool result = false;

        return result;
    }

    public List<PlayerCharacter> GetPlayerCharacters()
    {
        List<PlayerCharacter> playerCharacters = new List<PlayerCharacter>();
        foreach (Character character in turnOrder)
        {
            if (character is PlayerCharacter playerCharacter)
                playerCharacters.Add(playerCharacter);
        }
        return playerCharacters;
    }
}
