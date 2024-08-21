using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile to shoot
    public float fireRate = 2f; // Time between shots
    public float projectileSpeed = 8f; // Speed of the projectile
    public float maxRange = 15f; // Maximum shooting range
    private float nextFireTime = 0f;

    void Update()
    {
        // Check if it's time to fire the next shot
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Find the closest enemy within range
        GameObject closestEnemy = FindClosestEnemyInRange();
        if (closestEnemy != null)
        {
            // Calculate direction towards the enemy
            Vector2 direction = closestEnemy.transform.position - transform.position;
            
            // Instantiate the projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            // Initialize the projectile with the direction
            projectile.GetComponent<Projectile>().Initialize(direction);
        }
    }

    GameObject FindClosestEnemyInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float shortestDistance = maxRange; // Only consider enemies within maxRange

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
