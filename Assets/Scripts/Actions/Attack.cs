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
        Debug.Log($"Attacking {target.gameObject}");
    }

    IEnumerator Targeting()
    {
        Debug.Log($"Target an Enemy.");
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, enemyLayer);
                if (hit)
                {
                    target = hit.collider.gameObject.GetComponent<Character>();
                    still_looking = false;
                }
            }
            yield return null;
        }
    }
}
