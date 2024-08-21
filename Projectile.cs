using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile
    public int damage = 5; // Damage dealt by the projectile

    private Vector2 direction; // Direction to move

    public void Initialize(Vector2 direction)
    {
        this.direction = direction.normalized; // Normalize the direction
    }

    void Update()
    {
        // Move the projectile in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Optionally, destroy the projectile after some time or when it's off-screen
        // Destroy(gameObject, 3f); // Example: Destroy after 3 seconds
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the projectile hits an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the projectile after hitting the enemy
            Destroy(gameObject);
        }
    }
}
