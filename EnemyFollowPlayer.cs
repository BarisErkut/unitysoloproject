using System.Collections;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 2f;
    public int damage = 5;
    public float damageCooldown = 1f; // Cooldown time in seconds

    private Coroutine damageCoroutine;
    private float lastDamageTime = -Mathf.Infinity; // Initialize with a time in the past

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                float currentTime = Time.time;
                if (currentTime - lastDamageTime >= damageCooldown) // Check cooldown
                {
                    lastDamageTime = currentTime; // Update the last damage time
                    if (damageCoroutine == null) // Start coroutine if not already running
                    {
                        damageCoroutine = StartCoroutine(ApplyDamageOverTime(playerHealth));
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (damageCoroutine != null) // Stop coroutine if the player leaves
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator ApplyDamageOverTime(PlayerHealth playerHealth)
    {
        while (true) // Infinite loop, will be controlled by OnTriggerExit2D
        {
            playerHealth.TakeDamage(damage);
            yield return new WaitForSeconds(1f); // Wait for 1 second before applying damage again
        }
    }
}
