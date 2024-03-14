using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private PlayerLives playerLivesScript;
    [SerializeField] private PlayerStateManager playerStateManagerScript;
    [SerializeField] private PlayerAirBoostScript playerAirBoostScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            HandleObstacleCollision();
        }

        if (other.CompareTag("AirBoost"))
        {
            HandleAirBoostCollision();
        }
    }

    private void HandleObstacleCollision()
    {
        if (playerLivesScript != null)
        {
            playerLivesScript.PlayerLivesCount--;
        }

        if (playerStateManagerScript != null)
        {
            playerStateManagerScript.PlayerState = PlayerStates.Dead;
        }
    }

    private void HandleAirBoostCollision()
    {
        if (playerAirBoostScript != null)
        {
            playerAirBoostScript.IncreaseHeight();
        }
    }
}
