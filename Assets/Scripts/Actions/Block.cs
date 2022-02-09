using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Action
{
    public override void Perform(Character chara)
    {
        if (chara is PlayerCharacter character)
        {
            character.isBlocking = true;
            character.DeleteActions();
        }
        chara.EndTurn();
    }
}
