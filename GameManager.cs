using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Assign the new Panel here
    public Button restartButton;      // Assign the new Restart Button here

    void Start()
    {
        // Ensure the game over panel is not active at the start
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void EndLevel()
{
    // Find the player's camera
    Camera playerCamera = Camera.main;  // Assuming the main camera is the player's camera
    
    // Calculate the position in front of the camera
    Vector3 panelPosition = playerCamera.transform.position + playerCamera.transform.forward * 2f;
    
    // Set the panel position and rotation
    gameOverPanel.transform.position = panelPosition;
    gameOverPanel.transform.rotation = playerCamera.transform.rotation;

    // Activate the panel
    gameOverPanel.SetActive(true);

    // Freeze the game
    Time.timeScale = 0f;
}

    void RestartGame()
    {
        Time.timeScale = 1f;  // Unfreeze the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}