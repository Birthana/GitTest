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
    public Character[] turnOrder;

    private void Start()
    {
        TakeTurn(turnOrder[0]);
    }

    private void TakeTurn(Character character)
    {
        //Spawn Attack, Magic, Block, Run Choices.
        //Wait for player to choose.
        //Perform Action.
        //Go to next character turn or do another action.
        //If Enemy, choose random action or smart action choice.
    }
}
