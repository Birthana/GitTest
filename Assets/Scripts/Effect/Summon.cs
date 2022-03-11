using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Summon", menuName = "Effect/Summon")]
public class Summon : Effect
{
    public Character character;
    private BattleSystem bs;

    public override void CardEffect(List<Character> characters)
    {
        //Reduce Int by 1. When leaves, gain 1 Int.
        bs = FindObjectOfType<BattleSystem>();
        Character newCharacter = Instantiate(character, characters[0].transform);
        bs.AddToTurnOrder(newCharacter);
    }

    public override string GetCardEffectDescription()
    {
        throw new System.NotImplementedException();
    }
}
