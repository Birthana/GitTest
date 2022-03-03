using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DrawCard", menuName = "Effect/Draw")]
public class DrawCard : Effect
{
    public int numberOfCards;

    public override void CardEffect(List<Character> characters)
    {
        Debug.Log($"Drawing {numberOfCards} cards.");
        foreach (Character character in characters)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                character.Draw();
            }
        }
    }


    public override string GetCardEffectDescription()
    {
        return $"";
    }
}
