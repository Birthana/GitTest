using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Health : MonoBehaviour
{
    private Stats stats;
    [SerializeField]
    private int currentHealth;

    private void Awake()
    {
        stats = GetComponent<Stats>();
        currentHealth = stats.statValues[(int)Stats.Stat_Type.HP];
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
    }
}
