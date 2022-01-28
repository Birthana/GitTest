using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    private Character target;

    public override void Perform(Character character)
    {
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        yield return StartCoroutine(Targeting());
        //Make Health Component.
        //Deal damage to target HP equal to Character's POW.
        //If enemy is blocking, reduce damage by target's DEF.
    }

    IEnumerator Targeting()
    {
        //Physics Raycast to get enemy character.
        yield return new WaitForSeconds(1.0f);
    }
}
