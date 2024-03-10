using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private PlayerLives playerLivesScript;
    [SerializeField] private PlayerStateManager playerStateManagerScript;
    [SerializeField] private PlayerAirBoostScript playerAirBoostScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerLivesScript.PlayerLivesCount -= 1;
            playerStateManagerScript.PlayerState = PlayerStates.Dead;
            Debug.Log("Player has lost a life.");
        }

        if (other.gameObject.CompareTag("AirBoost"))
        {
            playerAirBoostScript.IncreaseingHeight();
        }
    }
}
