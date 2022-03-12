using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    public List<Card> cards;
    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
        foreach (Card card in cards)
        {
            character.AddCardToDeck(card);
        }
    }
}
