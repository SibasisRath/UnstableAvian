using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Camera mainCamera;
    [SerializeField] private float playerSpeed;
    private float currentSpeed;
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float upLimit;
    [SerializeField] private float downLimit;


    private void Start()
    {
        currentSpeed = playerSpeed;
        mainCamera = Camera.main;

        leftLimit = mainCamera.transform.position.x + leftLimit;
        rightLimit = mainCamera.transform.position.x + rightLimit;
        upLimit = mainCamera.transform.position.y + upLimit;
        downLimit = mainCamera.transform.position.y + downLimit;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 newPosition = player.transform.position + new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * currentSpeed;

        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);
        newPosition.y = Mathf.Clamp(newPosition.y, downLimit, upLimit);

        player.transform.position = newPosition;
    }
}
