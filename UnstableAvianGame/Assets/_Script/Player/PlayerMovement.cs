using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStateManager playerStateManager;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float playerSpeed;
    private float verticalInput;
    private float horizontalInput;

    [SerializeField] private float horizontalOffset = 0.1f; // Adjust horizontal offset value
    [SerializeField] private float verticalOffset = 0.1f;   // Adjust vertical offset value

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private UnityEvent jumpAndExplosion;

    private void Update()
    {
        Movement();
        if (playerStateManager.PlayerState == PlayerStates.Exploding && Input.GetKeyDown(jumpKey))
        {
            playerStateManager.PlayerState = PlayerStates.Alive;
            jumpAndExplosion.Invoke();
        }
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize();
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        float clampedX = Mathf.Clamp01(viewportPosition.x + movement.x * playerSpeed * Time.deltaTime);
        float clampedY = Mathf.Clamp01(viewportPosition.y + movement.y * playerSpeed * Time.deltaTime);

        clampedX = Mathf.Clamp(clampedX, horizontalOffset, 1f - horizontalOffset);
        clampedY = Mathf.Clamp(clampedY, verticalOffset, 1f - verticalOffset);

        viewportPosition = new Vector3(clampedX, clampedY, viewportPosition.z);
        Vector3 newPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        transform.position = newPosition;
    }
}
