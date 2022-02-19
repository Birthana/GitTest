using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "Card/Fireball")]
public class Fireball : Card
{
    public LayerMask enemyLayer;
    public int damage;
    public string cardEffect;

    public override IEnumerator DoEffect(PlayerCharacter playerCharacter)
    {
        Debug.Log($"Target an Enemy.");
        bool still_looking = true;
        while (still_looking)
        {
            GameObject hit = Utility.WaitForMouseClick(enemyLayer, () => still_looking = false);
            if (hit != null)
            {
                Character target = hit.GetComponent<Character>();
                target.ChangeHealth(damage);
                Debug.Log($"Dealing {damage} damage to {target}.");
            }
            yield return null;
        }
    }

    public string GetCardEffect()
    {
        return string.Format(cardEffect, damage);
    }
}
