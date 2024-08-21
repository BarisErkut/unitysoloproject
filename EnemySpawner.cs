using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool objectPool;
    public float spawnInterval = 2f;
    private float nextSpawnTime;
    public float spawnRange = 20f; // The range within which enemies will spawn near the player

    public Transform playerTransform; // Reference to the player's position

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = objectPool.GetPooledObject();
        if (enemy != null)
        {
            // Ensure we are setting the position before activation
            Vector2 randomPosition = GetRandomSpawnPosition();
            enemy.transform.position = randomPosition;

            // Debugging to confirm the spawn position
            Debug.Log("Spawning enemy at: " + randomPosition);

            enemy.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No pooled objects available for spawning.");
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        // Get the player's current position
        Vector2 playerPosition = playerTransform.position;

        // Generate a random position within the specified range around the player
        float randomX = Random.Range(playerPosition.x - spawnRange, playerPosition.x + spawnRange);
        float randomY = Random.Range(playerPosition.y - spawnRange, playerPosition.y + spawnRange);

        return new Vector2(randomX, randomY);
    }
}
