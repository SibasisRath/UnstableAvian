using System.Collections;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerStates playerState;

    [SerializeField] private Collider playerCollider;
    private const float respawnDelay = 1f;
    public PlayerStates PlayerState { get => playerState; set => playerState = value; }

    private IEnumerator HandleDeadSequence()
    {
        PlayerState = PlayerStates.Respawnning;
        playerCollider.enabled = false;
       
        yield return new WaitForSeconds(respawnDelay);

        playerCollider.enabled = true;
        PlayerState = PlayerStates.Alive;
    }

    void Update()
    {
        if (PlayerState == PlayerStates.Dead && GameManagerScript.Instance.GameState != GameStates.Over)
        {
            StartCoroutine(HandleDeadSequence());
        }
    }
}
