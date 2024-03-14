using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LobbySceneUiManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject difficultyLevelPanel;

    private void ButtonSetUp(Button button, UnityAction unityAction)
    {
        if (button != null)
        {
            button.onClick.AddListener(unityAction);
        }
    }

    private void Awake()
    {
        ButtonSetUp(playButton, OnPlayButtonClicked);
        ButtonSetUp(quitButton, Application.Quit);
        ButtonSetUp(backButton, OnBackButtonClicked);
        ButtonSetUp(easyButton, () => LevelLoader.ModeSelector(DifficultyMode.Easy));
        ButtonSetUp(mediumButton, () => LevelLoader.ModeSelector(DifficultyMode.Medium));
        ButtonSetUp(hardButton, () => LevelLoader.ModeSelector(DifficultyMode.Hard));
    }

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        difficultyLevelPanel.SetActive(false);
    }

    private void OnPlayButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        difficultyLevelPanel.SetActive(true);
    }

    private void OnBackButtonClicked()
    {
        mainMenuPanel.SetActive(true);
        difficultyLevelPanel.SetActive(false);
    }
}
