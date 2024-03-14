using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    LobbyScene,
    GameScene
}

public class LevelLoader : MonoBehaviour
{

    private static Dictionary<SceneName, string> sceneNameMap = new Dictionary<SceneName, string>()
    {
        { SceneName.LobbyScene, "LobbyScene" },
        { SceneName.GameScene, "GameScene" },
    };
    public static void ModeSelector(DifficultyMode level)
    {
        LevelStates levelStates = LevelManagerScript.Instance.GetLevelStates(level);

        if (sceneNameMap.TryGetValue(SceneName.GameScene, out string sceneName))
        {
            switch (levelStates)
            {
                case LevelStates.Completed:
                case LevelStates.Unlocked:
                    SceneManager.LoadScene(sceneName);
                    GameManagerScript.Instance.CurrentMode = level;
                    break;
                case LevelStates.Locked:
                    Debug.Log($"Level {level} is locked.");
                    break;
                default:
                    break;
            }
        }
        else
        {
            Debug.LogError($"Scene name mapping not found for {SceneName.GameScene}");
        }

    }
}
