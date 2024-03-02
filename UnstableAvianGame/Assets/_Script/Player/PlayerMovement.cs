using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    /*[SerializeField] private GameObject player;*/
    private Camera mainCamera;
    [SerializeField] private float playerSpeed;
    private float currentSpeed;
    private float verticalInput;
    private float horizontalInput;

    public float horizontalOffset = 0.1f; // Adjust horizontal offset value
    public float verticalOffset = 0.1f;   // Adjust vertical offset value

    [SerializeField] private UnityEvent jumpAndExplosion;


    private void Start()
    {
        currentSpeed = 1;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        
        Movement();
        if (PlayerStateManager.PlayerState == PlayerStates.Exploding && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You saved.");
            PlayerStateManager.PlayerState = PlayerStates.Alive;
            jumpAndExplosion.Invoke();
        }
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Convert the player's current position from world space to viewport space
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Calculate clamped viewport position with offsets
        float clampedX = Mathf.Clamp01(viewportPosition.x + movement.x * currentSpeed * Time.deltaTime);
        float clampedY = Mathf.Clamp01(viewportPosition.y + movement.y * currentSpeed * Time.deltaTime);

        // Apply horizontal and vertical offsets
        clampedX = Mathf.Clamp(clampedX, horizontalOffset, 1f - horizontalOffset);
        clampedY = Mathf.Clamp(clampedY, verticalOffset, 1f - verticalOffset);

        // Set the clamped viewport position
        viewportPosition = new Vector3(clampedX, clampedY, viewportPosition.z);

        // Convert the clamped viewport position back to world space
        Vector3 newPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        // Update the player's position
        transform.position = newPosition;
    }
}
