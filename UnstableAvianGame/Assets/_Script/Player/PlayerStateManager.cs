using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateManager : MonoBehaviour
{
    //private static PlayerStateManager instance;
    private PlayerStates playerState;

    //public static PlayerStateManager Instance { get => instance; set => instance = value; }
    public PlayerStates PlayerState { get => playerState; set => playerState = value; }



    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerScript.GameState == GameStates.Running)
        {
            PlayerState = PlayerStates.Alive;
            Debug.Log("player Started playing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
