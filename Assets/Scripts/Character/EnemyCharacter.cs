using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public LayerMask cardLayer;
    public LayerMask playerLayer;
    private BattleSystem bs;

    public override void TakeTurn()
    {
        bs = FindObjectOfType<BattleSystem>();
        PlayerCharacter player = GetRandomPlayer();
        StartCoroutine(Blocking(player));
    }

    private PlayerCharacter GetRandomPlayer()
    {
        List<PlayerCharacter> playerCharacters = bs.GetPlayerCharacters();
        int rngIndex = UnityEngine.Random.Range(0, playerCharacters.Count);
        return playerCharacters[rngIndex];
    }

    private void DealDamage(Health targetHP, int blockReduction)
    {
        int damage = Mathf.Max(0, stats.GetStat(Stats.POW) - blockReduction);
        targetHP.TakeDamage(damage);
        Debug.Log($"Attacking {targetHP.gameObject} for {damage} damage. Blocked {blockReduction} damage.");
        EndTurn();
    }

    private IEnumerator Blocking(PlayerCharacter player)
    {
        Debug.Log($"Choose cards to block with.");
        Health targetHP = player.GetComponent<Health>();
        if (!player.isBlocking)
        {
            DealDamage(targetHP, 0);
            yield break;
        }
        int blockReduction = 0;
        bool still_looking = true;
        while (still_looking)
        {
            if (bs.HandIsEmpty())
                still_looking = false;
            Utility.WaitForMouseClick(playerLayer, () => {
                still_looking = false;
                player.isBlocking = false;
            });
            GameObject card = Utility.WaitForMouseClick(cardLayer, () => { });
            if (card != null)
            {
                blockReduction += player.GetStat(Stats.DEF);
                Debug.Log($"Currenting blocking {blockReduction} damage.");
                bs.RemoveFromHand(card.GetComponent<CardDisplay>());
                Destroy(card);
            }
            yield return null;
        }
        DealDamage(targetHP, blockReduction);
    }
}
