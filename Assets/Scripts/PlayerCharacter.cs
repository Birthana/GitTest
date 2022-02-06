using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public LayerMask actionLayer; 
    public List<Action> actionPrefabs = new List<Action>();
    private List<Action> actions = new List<Action>();

    public override void TakeTurn()
    {
        SpawnActions();
        StartCoroutine(ChooseAction());
    }

    private void SpawnActions()
    {
        foreach (Action action in actionPrefabs)
        {
            Action newAction = Instantiate(action, transform);
            actions.Add(newAction);
        }
    }

    public void DeleteActions()
    {
        foreach (Action action in actions)
        {
            Destroy(action.gameObject);
        }
        actions = new List<Action>();
    }

    IEnumerator ChooseAction()
    {
        Debug.Log($"Choose an Action.");
        bool still_looking = true;
        while (still_looking)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, actionLayer);
                if (hit)
                {
                    still_looking = false;
                    Action action = hit.collider.gameObject.GetComponent<Action>();
                    action.Perform(this);
                }
            }
            yield return null;
        }
    }
}
