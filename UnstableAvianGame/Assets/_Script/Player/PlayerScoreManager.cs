using UnityEngine;
using TMPro;
public class PlayerScoreManager : MonoBehaviour
{
    private float score;
    private DifficultyModeScriptableObject currentDifficultyMode;
    [SerializeField] private TextMeshProUGUI scoreText;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
       
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
