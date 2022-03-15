using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Summon", menuName = "Effect/Summon")]
public class Summon : Effect
{
    public Character character;
    private BattleSystem bs;
    //Effects start at index 1 bc index 0 is itself.
    private List<Effect> effects = new List<Effect>();

    public override void CardEffect(List<Character> characters)
    {
        ReduceINT();
        bs = FindObjectOfType<BattleSystem>();
        Character newCharacter = Instantiate(character, characters[0].transform);
        newCharacter.OnDeath += IncreaseINT;
        for (int i = 1; i < effects.Count; i++)
        {
            if(effects[i].keyword != null)
                effects[i].keyword.AddToEvent(effects[i].DoEffect, newCharacter);
        }
        bs.AddToTurnOrder(newCharacter);
    }

    public void ReduceINT()
    {
        character.ChangeStat(Stats.INT, -1);
    }

    public void IncreaseINT()
    {
        character.ChangeStat(Stats.INT, 1);
    }

    public override string GetCardEffectDescription()
    {
        throw new System.NotImplementedException();
    }

    public void SetEffects(List<Effect> effects)
    {
        this.effects = effects;
    }
}
