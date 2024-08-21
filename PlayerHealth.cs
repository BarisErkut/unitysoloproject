using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth= 100;
    private int currentHealth;
    private GameManager gameManager;
    public int CurrentHealth    // Public property to access currentHealth
    {
        get { return currentHealth; }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentHealth=maxHealth;
    }
    public void TakeDamage(int damageAmount){
        currentHealth-=damageAmount;
        Debug.Log("Player took damage. Current health: " + currentHealth); 
        if (currentHealth<=0){
            Die();
        }
    }
    void Die(){
        Debug.Log("Player has died");
        gameManager.EndLevel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
