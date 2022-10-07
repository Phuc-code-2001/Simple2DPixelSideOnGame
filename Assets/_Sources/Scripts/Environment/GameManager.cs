using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameState {
        Menu,
        Loading,
        Playing,
        Pausing,
        Ending,
    }

    public enum GameStartMode
    {
        NewGame,
        ContinueGame,
    }

    public static GameManager Instance;

    public GameState CurrentGameState;
    public GameStartMode StartMode;

    public int CurrentSceneIndex = 0;
    [SerializeField] private int NumberOfScenes;

    [Header("Canvas UI")]
    public GameObject MenuUI;
    public GameObject PauseUI;
    public GameObject SetupUI;


    public void LoadScene(int sceneIndex)
    {
        var loadSceneProcess = SceneManager.LoadSceneAsync(sceneIndex);
        // Show Loadding

        CurrentSceneIndex = sceneIndex;
    }

    public void LoadNextScene()
    {
        LoadScene(CurrentSceneIndex + 1);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            NumberOfScenes = SceneManager.sceneCountInBuildSettings;
        }
    }

    public void StartGame()
    {
        if(NumberOfScenes > 1)
        {

            // Start a new save record

            LoadScene(1);
            CurrentGameState = GameState.Playing;
            StartMode = GameStartMode.NewGame;

            MenuUI.SetActive(false);
            SetupUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("StartGame: Scene not found");
        }
    }

    public void Continue()
    {
        StartMode = GameStartMode.ContinueGame;
    }

    public void SaveGame()
    {

    }

    public void LoadMenu()
    {
        SaveGame();
        LoadScene(0);

        MenuUI.SetActive(true);
        SetupUI.SetActive(false);
        PauseUI.SetActive(false);

        ResumeTime();
    }


    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        PauseTime();
        PauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        ResumeTime();
        PauseUI.SetActive(false);
    }

    public void GameOver()
    {
        
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

}
