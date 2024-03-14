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
    }

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
