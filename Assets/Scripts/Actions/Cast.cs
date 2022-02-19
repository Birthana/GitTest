using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : Action
{
    public LayerMask cardLayer;
    public LayerMask playerLayer;
    private BattleSystem bs;

    public override void Perform(Character character)
    {
        bs = FindObjectOfType<BattleSystem>();
        StartCoroutine(Casting((PlayerCharacter)character));
    }

    IEnumerator Casting(PlayerCharacter attackCharacter)
    {
        Debug.Log($"Choose cards to cast.");
        int numberOfCardsToCast = attackCharacter.GetStat(Stats.INT);
        bool still_looking = true;
        while (still_looking)
        {
            if (bs.HandIsEmpty() || numberOfCardsToCast <= 0)
                still_looking = false;
            Utility.WaitForMouseClick(playerLayer, () => {
                still_looking = false;
            });
            GameObject card = Utility.WaitForMouseClick(cardLayer, () => { });
            if (card != null)
            {
                numberOfCardsToCast--;
                Debug.Log($"Casting this {card.GetComponent<CardDisplay>().card.name}.");
                yield return card.GetComponent<CardDisplay>().card.DoEffect(attackCharacter);
            }
            yield return null;
        }
        attackCharacter.EndTurn();
    }
}
