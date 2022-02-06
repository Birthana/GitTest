using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    private BattleSystem bs;

    public override void TakeTurn()
    {
        bs = FindObjectOfType<BattleSystem>();
        DealDamageToRandomPlayer();
        bs.NextTurn();
    }

    private void DealDamageToRandomPlayer()
    {
        List<PlayerCharacter> playerCharacters = bs.GetPlayerCharacters();
        int rngIndex = UnityEngine.Random.Range(0, playerCharacters.Count);
        Health playerHealth = playerCharacters[rngIndex].GetComponent<Health>();
        int damage = stats.GetStat(Stats.POW);
        playerHealth.TakeDamage(damage);
        Debug.Log($"Attacking {playerHealth.gameObject} for {damage} damage.");
    }
}
