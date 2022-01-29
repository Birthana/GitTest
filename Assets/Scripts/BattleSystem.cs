using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Actions:
     * 1. Attack - Deal Weapon Damage to an opponent. Perform a Trigger Check.
     * 2. Card Magic - Can be performed equal the character's INT. Spells, Abilities, or Items can be activated for MANA in this character's hand.
     * 3. Block - Opponent must attack this character. Before being dealt damage, you can discard cards to reduce damage by your character's DEF.
     * 4. Run - Leave the battle.
     * 
     * At the start of turn, each character draws a card, that can be used for Card Magic or Blocking.
     * When using the Attack action or taking damage after taking the Block action, draw a card & check the Trigger.
     * When a Trigger is revealed from this, apply one of the following effects:
     *  - Crit: During this characters next Attack action, damage is doubled.
     *  - Draw: This character draws 1 card.
     *  - Stand: Another character can Attack or Block now.
     *  - Heal: This character healed for the damage dealt instead.
     *  
     *  Character Stats:
     *      HP
     *      MANA
     *      POW
     *      DEF
     *      INT
     *      SPD
     */
public class BattleSystem : MonoBehaviour
{
    public LayerMask actionLayer;
    public List<Action> actionPrefabs = new List<Action>();
    public Character[] turnOrder;
    private List<Action> actions = new List<Action>();
    private int currentIndex = 0;

    private void Start()
    {
        TakeTurn(turnOrder[0]);
    }

    //
    //Spawn Attack, Magic, Block, Run Choices.
    //Wait for player to choose.
    //Perform Action.
    //Go to next character turn or do another action.
    //If Enemy, choose random action or smart action choice.
    private void TakeTurn(Character character)
    {
        character.Draw();
        StartCoroutine(ChooseAction(character));
    }

    IEnumerator ChooseAction(Character character)
    {
        DisplayActions();
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
                    action.Perform(character);
                }
            }
            yield return null;
        }
        NextTurn();
    }

    private void NextTurn()
    {
        if (CheckIfCombatDone())
            return;
        currentIndex++;
        if (currentIndex < turnOrder.Length)
            currentIndex = 0;
        TakeTurn(turnOrder[currentIndex]);
    }

    private bool CheckIfCombatDone()
    {
        bool result = true;

        return result;
    }

    private void DisplayActions()
    {
        foreach (Action action in actionPrefabs)
        {
            Action newAction = Instantiate(action, transform);
            actions.Add(newAction);
        }
    }
}
