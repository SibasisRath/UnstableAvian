using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class PlayerScoreManager : MonoBehaviour
{
    private float score;
    private DifficultyModeScriptableObject currentDifficultyMode;
    [SerializeField] private TextMeshProUGUI scoreText;
    private List<DifficultyModeScriptableObject> difficultyModes;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
       difficultyModes = GameManagerScript.Instance.GetDifficultyModeScriptableObjects();
    }

    // Update is called once per frame
    void Update()
    {
        currentDifficultyMode = GameManagerScript.Instance.GetCurrentDifficultyModeInfo();
        if (GameManagerScript.Instance.GameState != GameStates.Pause)
        {
            score += Time.deltaTime * GetScoreMultiplier(currentDifficultyMode.DifficultyMode);
            UpdateScoreText();
        }

        if (difficultyModes.IndexOf(currentDifficultyMode) + 1 != difficultyModes.Count && difficultyModes[difficultyModes.IndexOf(currentDifficultyMode) + 1].ScoreToInitiate <= score)
        {
            GameManagerScript.Instance.CurrentMode = difficultyModes[difficultyModes.IndexOf(currentDifficultyMode) + 1].DifficultyMode;
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score:\n{score}";
    }

    private float GetScoreMultiplier(DifficultyMode difficultyMode)
    {
        float scoreMultiplier = 0;

        switch (difficultyMode)
        {
            case DifficultyMode.Easy:
                scoreMultiplier = 1;
                break;
            case DifficultyMode.Medium:
                scoreMultiplier = 2; 
                break;
            case DifficultyMode.Hard:
                scoreMultiplier *= 2;
                break;
            default:
                break;
        }

        return scoreMultiplier;
    }
}
