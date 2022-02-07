using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Action
{
    private BattleSystem bs;

    public override void Perform(Character chara)
    {
        bs = FindObjectOfType<BattleSystem>();
        if (chara is PlayerCharacter character)
            character.isBlocking = true;
        bs.NextTurn();
    }
}
