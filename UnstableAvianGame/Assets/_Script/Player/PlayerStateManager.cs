using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateManager : MonoBehaviour
{
    private static PlayerStateManager instance;
    private static PlayerStates playerState;

    public static PlayerStateManager Instance { get => instance; set => instance = value; }
    public static PlayerStates PlayerState { get => playerState; set => playerState = value; }



    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerScript.Instance.GameState == GameStates.Running)
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
