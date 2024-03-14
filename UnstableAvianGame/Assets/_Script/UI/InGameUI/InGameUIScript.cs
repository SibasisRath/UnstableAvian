using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIScript : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button resumeButton;

    private int mainMenuSceneIndex = 0;

    private void Start()
    {
        SetPanelsAndButtonsActive(false);
        SetupButtonListeners();
        GameManagerScript.Instance.GameState = GameStates.Running;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (GameManagerScript.Instance.GameState == GameStates.Over)
        {
            HandleGameOver();
        }
    }

    private void PauseGame()
    {
        GameManagerScript.Instance.GameState = GameStates.Pause;
        SetPanelsAndButtonsActive(true);
    }

    private void ResumeGame()
    {
        GameManagerScript.Instance.GameState = GameStates.Running;
        SetPanelsAndButtonsActive(false);
    }

    private void HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainButton.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManagerScript.Instance.GameState = GameStates.Running;
        SetPanelsAndButtonsActive(false);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    private void SetPanelsAndButtonsActive(bool isActive)
    {
        pausePanel.SetActive(isActive);
        gameOverPanel.SetActive(isActive);
        restartButton.gameObject.SetActive(isActive);
        mainButton.gameObject.SetActive(isActive);
        resumeButton.gameObject.SetActive(isActive);
    }

    private void SetupButtonListeners()
    {
        restartButton.onClick.AddListener(RestartGame);
        resumeButton.onClick.AddListener(ResumeGame);
        mainButton.onClick.AddListener(ReturnToMainMenu);
    }
}
