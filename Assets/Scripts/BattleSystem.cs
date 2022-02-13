using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleSystem : MonoBehaviour
{
    public Character[] turnOrder;
    private int currentIndex = 0;
    [SerializeField]
    private List<Card> hand = new List<Card>();

    private void Start()
    {
        SetEvents();
        TakeTurn(turnOrder[0]);
    }

    private void TakeTurn(Character character)
    {
        Debug.Log($"{character.gameObject.name}'s Turn.");
        character.OnEndTurn += NextTurn;
        character.TakeTurn();
    }

    public void AddToHand(Card card) => hand.Add(card);

    public void NextTurn()
    {
        if (CheckIfCombatDone())
            return;
        ResetEvents();
        currentIndex++;
        if (currentIndex >= turnOrder.Length)
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
        return hand.Count == 0;
    }
}
