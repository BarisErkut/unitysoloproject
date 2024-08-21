using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    void OnEnable()
    {
        // Reset health when the enemy is enabled (spawned or respawned)
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add any death effects here (e.g., animations, sound)
        gameObject.SetActive(false);  // Deactivate the object instead of destroying it
    }
}