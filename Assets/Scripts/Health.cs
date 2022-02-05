using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Health : MonoBehaviour
{
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    private void Awake()
    {
        maxHealth = GetComponent<Stats>().GetStat(Stats.Stat_Type.HP);
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        if (currentHealth == 0)
            Debug.Log($"{name} is defeated.");
    }
}
