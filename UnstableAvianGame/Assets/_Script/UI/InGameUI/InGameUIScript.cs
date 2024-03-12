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



    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
        resumeButton.onClick.AddListener(ResumeMethod);
        mainButton.onClick.AddListener(BackToMainGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMethod();
        }
        if (GameManagerScript.Instance.GameState == GameStates.Over)
        {
            GameOverMethod();
        }
    }


    private void PauseMethod()
    {
        GameManagerScript.Instance.GameState = GameStates.Pause;
        pausePanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
    }

    private void ResumeMethod()
    {
        GameManagerScript.Instance.GameState = GameStates.Running;
        pausePanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    private void GameOverMethod()
    {
        gameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainButton.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManagerScript.Instance.GameState = GameStates.Running;
        gameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainButton.gameObject.SetActive(false);
    }

    private void BackToMainGame()
    {
        SceneManager.LoadScene(0);
       
    }
}
