using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerStates playerState;

    [SerializeField] private Collider playerCollider;
    public PlayerStates PlayerState { get => playerState; set => playerState = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerScript.Instance.GameState == GameStates.Running)
        {
            PlayerState = PlayerStates.Alive;
        }

        
    }

    private IEnumerator PlayerDeadSequence()
    {
        PlayerState = PlayerStates.Respawnning;
        playerCollider.enabled = false;
        Debug.Log("Player death sequence started and collider off.");
        yield return new WaitForSeconds(1);

        playerCollider.enabled = true;
        PlayerState = PlayerStates.Alive;
        Debug.Log("Player death sequence finished and collider on.");


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerState == PlayerStates.Dead && GameManagerScript.Instance.GameState != GameStates.Over)
        {
            StartCoroutine(PlayerDeadSequence());
        }
    }
}
