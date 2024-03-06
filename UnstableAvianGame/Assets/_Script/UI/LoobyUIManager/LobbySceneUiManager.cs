using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LobbySceneUiManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;

    [SerializeField] private GameObject mainMenuPannel;
    [SerializeField] private GameObject difficultyLevelPannel;
    

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
        ButtonSetUp(quitButton, OnQuitButtonClicked);
        ButtonSetUp(backButton, OnBackButtonClicked);
        ButtonSetUp(tutorialButton, OnTutorialButtonClicked);
        ButtonSetUp(easyButton, OnEasyButtonClicked);
        ButtonSetUp(mediumButton, OnMediumButtonClicked);
        ButtonSetUp(hardButton, OnHardButtonClicked);
    }

    private void Start()
    {
        difficultyLevelPannel.SetActive(false);
        mainMenuPannel.SetActive(true);
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void OnPlayButtonClicked()
    {
        mainMenuPannel.SetActive(false);
        difficultyLevelPannel.SetActive(true);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
    private void OnTutorialButtonClicked()
    {
       LevelLoader.ModeSelector(DifficultyMode.Tutorial);
    }
    private void OnEasyButtonClicked()
    {
        LevelLoader.ModeSelector(DifficultyMode.Easy);
    }
    private void OnMediumButtonClicked()
    {
        LevelLoader.ModeSelector(DifficultyMode.Medium);
    }

    private void OnHardButtonClicked()
    {
        LevelLoader.ModeSelector(DifficultyMode.Hard);
    }
    private void OnBackButtonClicked()
    {
        mainMenuPannel.SetActive(true);
        difficultyLevelPannel.SetActive(false);
    }
}
