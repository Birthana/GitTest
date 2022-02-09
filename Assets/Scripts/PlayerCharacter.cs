using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public event System.Action<Card> OnTriggerCheck;
    public LayerMask actionLayer; 
    public List<Action> actionPrefabs = new List<Action>();
    private List<Action> actions = new List<Action>();
    public bool isBlocking { get; set; }

    public override void TakeTurn()
    {
        SpawnActions();
        StartCoroutine(ChooseAction());
    }

    public Card.Trigger TriggerCheck(Character character)
    {
        Card.Trigger result = Card.Trigger.NONE;
        Card triggerCheck = character.Draw();
        if (triggerCheck != null)
            result = triggerCheck.trigger;
        OnTriggerCheck(triggerCheck);
        return result;
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
