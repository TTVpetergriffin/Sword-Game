using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCamera : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;
    public float yOffset; // Adjust this value for the Y offset

    private Vector2 currentRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentRotation.x -= mouseY;
        currentRotation.y += mouseX;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);

        transform.localRotation = Quaternion.Euler(currentRotation.x, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f, currentRotation.y, 0f);

        // Camera following player with Y offset
        Vector3 desiredPosition = playerBody.position + yOffset * Vector3.up;
        transform.position = desiredPosition;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            yOffset = 0.5f;
        }
        else 
        {
            yOffset = 1.0f;
        }
    }
}



