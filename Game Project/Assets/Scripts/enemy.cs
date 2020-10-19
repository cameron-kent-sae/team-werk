using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        // Play injury animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Die animation

        // Disable the enemy
    }
}
