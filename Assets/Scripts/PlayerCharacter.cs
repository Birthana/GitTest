using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public event System.Action<Card> OnHandChange;
    public LayerMask actionLayer; 
    public List<Action> actionPrefabs = new List<Action>();
    private List<Action> actions = new List<Action>();
    public bool isBlocking { get; set; }

    public override void TakeTurn()
    {
        OnHandChange(Draw());
        SpawnActions();
        StartCoroutine(ChooseAction());
    }

    public void DrawTrigger()
    {
        OnHandChange(Draw());
    }

    public Card.Trigger TriggerCheck()
    {
        Card.Trigger result = Card.Trigger.NONE;
        Card triggerCheck = Draw();
        if (triggerCheck != null)
            result = triggerCheck.trigger;
        OnHandChange(triggerCheck);
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
            GameObject temp = Utility.WaitForMouseClick(actionLayer, () => still_looking = false);
            if(temp != null)
            {
                Action action = temp.GetComponent<Action>();
                action.Perform(this);
            }
            yield return null;
        }
    }
}
