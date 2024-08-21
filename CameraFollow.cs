using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float zoomSpeed = 2f;    // Speed of zooming
    public float minZoom = 10f;     // Minimum zoom level
    public float maxZoom = 30f;     // Maximum zoom level

    void LateUpdate()
    {
        // Handle Zoom
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize -= scrollData * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);

        // Determine the desired camera position based on the player's position and the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
