using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public LayerMask cardLayer;
    public LayerMask playerLayer;
    private BattleSystem bs;
    private PlayerCharacter player;

    public override void TakeTurn()
    {
        bs = FindObjectOfType<BattleSystem>();
        GetRandomPlayer();
        StartCoroutine(Blocking());
    }

    private void GetRandomPlayer()
    {
        List<PlayerCharacter> playerCharacters = bs.GetPlayerCharacters();
        int rngIndex = UnityEngine.Random.Range(0, playerCharacters.Count);
        player = playerCharacters[rngIndex];
    }

    private void DealDamage(int blockReduction)
    {
        int damage = Mathf.Max(0, stats.GetStat(Stats.POW) - blockReduction);
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.TakeDamage(damage);
        Debug.Log($"Attacking {playerHealth.gameObject} for {damage} damage. Blocked {blockReduction} damage.");
        EndTurn();
    }

    private IEnumerator Blocking()
    {
        Debug.Log($"Choose cards to block with.");
        if (!player.isBlocking)
            DealDamage(0);
        int blockReduction = 0;
        bool still_looking = true;
        while (still_looking)
        {
            if (bs.HandIsEmpty())
                still_looking = false;
            WaitForMouseClick(playerLayer, () => still_looking = false);
            WaitForMouseClick(cardLayer, () => {
                blockReduction += player.GetStat(Stats.DEF);
                Debug.Log($"Currenting blocking {blockReduction} damage.");
            });
            yield return null;
        }
        DealDamage(blockReduction);
    }

    private void WaitForMouseClick(LayerMask layer, System.Action doAction)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, layer);
            if (hit)
            {
                doAction();
            }
        }
    }
}
