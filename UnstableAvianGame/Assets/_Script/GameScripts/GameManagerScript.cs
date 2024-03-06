using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private List<DifficultyModeScriptableObject> difficultyModes;
    private static GameManagerScript instance;
    private GameStates gameState;
    private DifficultyMode currrentMode;
    private DifficultyModeScriptableObject currentDifficultyModeInfo;

    public static GameManagerScript Instance { get => instance; set => instance = value; }
    public GameStates GameState { get => gameState; set => gameState = value; }

    public DifficultyModeScriptableObject GetCurrentDifficultyModeInfo()
    {
        return currentDifficultyModeInfo;
    }
    public void SetCurrentDifficultyModeInfo(DifficultyMode difficultyMode)
    {
        currentDifficultyModeInfo = difficultyModes.Find(obj => obj.DifficultyMode == difficultyMode);
    }

    public DifficultyMode CurrrentMode
    {
        get => currrentMode;
        set
        {
            currrentMode = value;
            SetCurrentDifficultyModeInfo(currrentMode);
            Debug.Log(currrentMode);
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
