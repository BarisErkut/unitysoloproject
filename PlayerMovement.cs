using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Player speed
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public float mapWidth = 200f; // Map width
    public float mapHeight = 200f; // Map height

    private float halfPlayerWidth;
    private float halfPlayerHeight;

    void Start()
    {
        // Setting the player's starting position to the center of the map
        transform.position = new Vector3(100f, 100f, 0f);
        rb = GetComponent<Rigidbody2D>();
        halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        halfPlayerHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        // Get input
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // Ensure consistent speed in all directions

        // Calculate velocity
        moveVelocity = moveInput * speed;
    }

    void FixedUpdate()
    {
        // Calculate new position
        Vector2 newPosition = rb.position + moveVelocity * Time.fixedDeltaTime;

        // Clamp player position within map boundaries
        float clampedX = Mathf.Clamp(newPosition.x, halfPlayerWidth, mapWidth - halfPlayerWidth);
        float clampedY = Mathf.Clamp(newPosition.y, halfPlayerHeight, mapHeight - halfPlayerHeight);

        rb.MovePosition(new Vector2(clampedX, clampedY));
    }
}

