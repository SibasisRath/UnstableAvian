using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private PlayerLives playerLivesScript;
    [SerializeField] private PlayerStateManager playerStateManagerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerLivesScript.PlayerLivesCount -= 1;
            playerStateManagerScript.PlayerState = PlayerStates.Dead;
            Debug.Log("Player has lost a life.");
        }
    }
}
