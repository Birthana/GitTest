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
        if (character is PlayerCharacter playerCharacter)
        {
            AddToHand(playerCharacter.Draw());
            playerCharacter.OnTriggerCheck += AddToHand;
        }
        character.OnEndTurn += NextTurn;
        character.TakeTurn();
    }

    public void AddToHand(Card card) => hand.Add(card);

    public void NextTurn()
    {
        if (CheckIfCombatDone())
            return;
        Character currentCharcter = turnOrder[currentIndex];
        currentCharcter.OnEndTurn -= NextTurn;
        if (currentCharcter is PlayerCharacter playerCharacter)
        {
            playerCharacter.OnTriggerCheck -= AddToHand;
            playerCharacter.DeleteActions();
        }
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

    public bool HandIsEmpty() 
    {
        return hand.Count == 0;
    }
}
