using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public LayerMask actionLayer;
    public List<Action> actionPrefabs = new List<Action>();
    private List<Action> actionButtons = new List<Action>();

    public override void TakeTurn()
    {
        SpawnActions();
        StartCoroutine(Choosing());
    }

    private void SpawnActions()
    {
        Debug.Log($"Choose an Action.");
        foreach (Action action in actionPrefabs)
        {
            Action newAction = Instantiate(action, transform);
            newAction.SetOwner(this);
            actionButtons.Add(newAction);
        }
    }

    IEnumerator Choosing()
    {
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, actionLayer);
                if (hit)
                {
                    still_looking = false;
                    Action action = hit.collider.GetComponent<Action>();
                    yield return StartCoroutine(action.Perform());
                }
            }
            yield return null;
        }
        BattleSystem bs = FindObjectOfType<BattleSystem>();
        bs.NextTurn();
    }
}
