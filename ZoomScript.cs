using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScript : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomSpeed = 2f; // Speed of zooming in/out
    public float minZoom = 10f;  // Minimum zoom level (20 - 10 = 10)
    public float maxZoom = 30f;  // Maximum zoom level (20 + 10 = 30)

    void Start()
    {
        // If the camera is not assigned in the inspector, grab the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Handle zooming using the mouse scroll wheel
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        mainCamera.orthographicSize -= scrollData * zoomSpeed;

        // Clamp the zoom level to the min and max values
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
    }
}
