using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public List<Character> turnOrder = new List<Character>();
    private int currentIndex = 0;
    private Hand hand;

    private void Start()
    {
        hand = GetComponent<Hand>();
        SetEvents();
        TakeTurn(turnOrder[0]);
    }

    public void AddToTurnOrder(Character character)
    {
        turnOrder.Add(character);
    }

    private void TakeTurn(Character character)
    {
        Debug.Log($"{character.gameObject.name}'s Turn.");
        character.OnEndTurn += NextTurn;
        character.TakeTurn();
    }

    public void AddToHand(Card card)
    {
        hand.AddToHand(card);
    }

    public void RemoveFromHand(CardDisplay card)
    {
        hand.RemoveFromHand(card);
    }

    public void NextTurn()
    {
        if (CheckIfCombatDone())
            return;
        ResetEvents();
        currentIndex++;
        if (currentIndex >= turnOrder.Count)
            currentIndex = 0;
        TakeTurn(turnOrder[currentIndex]);
    }

    private void SetEvents()
    {
        foreach (Character character in turnOrder)
        {
            if (character is PlayerCharacter playerCharacter)
                playerCharacter.OnHandChange += AddToHand;
        }
    }

    private void ResetEvents()
    {
        Character currentCharacter = turnOrder[currentIndex];
        currentCharacter.OnEndTurn -= NextTurn;
        if(currentCharacter is PlayerCharacter playerCharacter)
            playerCharacter.DeleteActions();
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

    public bool HandIsEmpty() 
    {
        return hand.IsEmpty();
    }
}
