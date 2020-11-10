using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // public Animator animator;
    
    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Inflicts Damage and checks if enemy dies
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Disables enemy and will play death animation
    private void Die()
    {
        Debug.Log("Enemy Died");
        
        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
