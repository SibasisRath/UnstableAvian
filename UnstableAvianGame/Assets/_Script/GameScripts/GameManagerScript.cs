using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private static GameManagerScript instance;
    private static GameStates gameState;

    public static GameManagerScript Instance { get => instance; set => instance = value; }
    public static GameStates GameState { get => gameState; set => gameState = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        GameState = GameStates.Running;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
