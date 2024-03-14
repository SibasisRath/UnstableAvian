using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    private static LevelManagerScript instance;
    private const DifficultyMode defaulEasyLevel = DifficultyMode.Easy;

    public static LevelManagerScript Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetLevelStates(defaulEasyLevel, LevelStates.Unlocked);
    }

    public void OnLevelCompletion(DifficultyMode nextMode)
    {
        SetLevelStates(GameManagerScript.Instance.CurrentMode, LevelStates.Completed);
        SetLevelStates(nextMode, LevelStates.Unlocked);

    }

    public LevelStates GetLevelStates(DifficultyMode level)
    {
        LevelStates levelStates = (LevelStates)PlayerPrefs.GetInt(level.ToString(), 0);
        return levelStates;
    }
    public void SetLevelStates(DifficultyMode level, LevelStates levelStates)
    {
        PlayerPrefs.SetInt(level.ToString(), (int)levelStates);
        PlayerPrefs.Save();
    }
}
