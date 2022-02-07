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
        StartCoroutine(Blocking((blockReduction) => DealDamage(blockReduction)));
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
        bs.NextTurn();
    }

    private IEnumerator Blocking(Action<int> dealDamage)
    {
        Debug.Log($"Choose cards to block with.");
        if (!player.isBlocking)
            dealDamage(0);
        int blockReduction = 0;
        bool still_looking = true;
        while (still_looking)
        {
            if (bs.HandIsEmpty())
                still_looking = false;
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, playerLayer);
                RaycastHit2D hit2 = Physics2D.Raycast(mousePosition, Vector2.zero, 100, cardLayer);
                if (hit)
                {
                    still_looking = false;
                }
                if (hit2)
                {
                    //Return Card to Hand. Destroy Card in Scene. Add Character Def to result.
                    blockReduction += player.GetStat(Stats.DEF);
                    Debug.Log($"Currenting blocking {blockReduction} damage.");
                }
            }
            yield return null;
        }
        dealDamage(blockReduction);
    }
}
