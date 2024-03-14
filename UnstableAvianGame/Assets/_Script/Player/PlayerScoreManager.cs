using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class PlayerScoreManager : MonoBehaviour
{
    private float score = 0;
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
            score += Time.deltaTime * currentDifficultyMode.ScoreMultiplier;
            UpdateScoreText();
            CheckDifficultyModeChange();
        }        
    }

    private void CheckDifficultyModeChange()
    {
        int nextModeIndex = difficultyModes.IndexOf(currentDifficultyMode) + 1;
        if (nextModeIndex < difficultyModes.Count && difficultyModes[nextModeIndex].ScoreToInitiate <= score)
        {
            GameManagerScript.Instance.CurrentMode = difficultyModes[nextModeIndex].DifficultyMode;
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score:\n{Mathf.RoundToInt(score)}"; ;
    }
}
