using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Action
{
    private Character character;


    public override void Perform(Character chara)
    {
        character = chara;
        character.ToggleBlocking();
    }
}
