using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static void ModeSelector(DifficultyMode level)
    {

        LevelStates levelStates = LevelManagerScript.Instance.GetLevelStates(level);
        int sceneBuildIndex = 0;
        switch (levelStates)
        {
            case LevelStates.Completed:
            case LevelStates.Unlocked:
                sceneBuildIndex = 1;
                GameManagerScript.Instance.CurrentMode = (DifficultyMode)level;
                SceneManager.LoadScene(sceneBuildIndex);
                break;
            case LevelStates.Locked:
                Debug.Log("level is locked.");
                break;
            default:
                break;
        }

    }
}
