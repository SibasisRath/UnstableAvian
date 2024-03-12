using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private List<DifficultyModeScriptableObject> difficultyModes;
    private static GameManagerScript instance;
    private GameStates gameState;
    private DifficultyMode currentMode;
    private DifficultyModeScriptableObject currentDifficultyModeInfo;

    public static GameManagerScript Instance { get => instance; set => instance = value; }
    public GameStates GameState { get => gameState; set => gameState = value; }


    public List<DifficultyModeScriptableObject> GetDifficultyModeScriptableObjects()
    {
        return difficultyModes;
    }

    public DifficultyModeScriptableObject GetCurrentDifficultyModeInfo()
    {
        return currentDifficultyModeInfo;
    }
    public void SetCurrentDifficultyModeInfo(DifficultyMode difficultyMode)
    {
        currentDifficultyModeInfo = difficultyModes.Find(obj => obj.DifficultyMode == difficultyMode);
        LevelManagerScript.Instance.SetLevelStates(currentDifficultyModeInfo.DifficultyMode, LevelStates.Unlocked);
        Debug.Log(currentDifficultyModeInfo.DifficultyMode);
    }

    public DifficultyMode CurrentMode
    {
        get => currentMode;
        set
        {
            currentMode = value;
            SetCurrentDifficultyModeInfo(currentMode);
        }
    }
    private void Awake()
    {
        
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
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

    void Update()
    {
        if (gameState == GameStates.Pause || gameState == GameStates.Over)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }



    
}
