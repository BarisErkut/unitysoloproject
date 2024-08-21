using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Transform playerTransform;
    public Vector3 offset; // To position the health bar above the player

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = playerTransform.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth;
            healthSlider.value = playerHealth.CurrentHealth;
        }
    }

    void Update()
    {
        // Update the health bar value
        if (playerHealth != null)
            {
            healthSlider.value = playerHealth.CurrentHealth;
            }
        if (playerHealth.CurrentHealth <= 0)
        {
            healthSlider.fillRect.gameObject.SetActive(false);
        }
        else
        {
            healthSlider.fillRect.gameObject.SetActive(true);
        }
        // Position the health bar above the player
        transform.position = playerTransform.position + offset;
    }
}


