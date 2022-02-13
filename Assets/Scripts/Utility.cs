using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static GameObject WaitForMouseClick(LayerMask layer, System.Action doAction)
    {
        RaycastHit2D hit = CheckForMouseClick(layer);
        if (hit)
        {
            doAction();
            return hit.collider.gameObject;
        }
        return null;
    }

    private static RaycastHit2D CheckForMouseClick(LayerMask layer)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, layer);
            return hit;
        }
        return new RaycastHit2D();
    }
}
