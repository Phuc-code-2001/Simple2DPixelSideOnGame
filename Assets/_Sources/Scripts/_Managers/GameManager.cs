using Assets._Sources.Scripts.SaveAndLoadData;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameState {
        Menu,
        Loading,
        Playing,
        Pausing,
        Ending,
    }

    public static GameManager Instance;

    public SaveGameManager SaveGameManager = new SaveGameManager();
    public List<Record> Records;
    public Record SelectedRecord = Record.GetDefault();

    public GameState CurrentGameState;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        Instance = this;

        LoadDatabase();

    }

    public void LoadDatabase()
    {
        Records = SaveGameManager.GetRecords();
        if(Records.Count > 0)
        {
            SelectedRecord = Records.FirstOrDefault();
        }
    }

    public void SaveGame()
    {
        SelectedRecord = SaveGameManager.SaveRecord(SelectedRecord, SelectedRecord.Id != 0);
    }

    public void UpdateRecord()
    {
        int SceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneCount)
        {
            if(nextSceneIndex > SelectedRecord.MaxLevelIndex)
            {
                SelectedRecord.MaxLevelIndex = nextSceneIndex;
            }
        }
        SelectedRecord.Coin += PlayerController.Instance.playerInfoController.Coin;

        SaveGame();
    }

    public void Restart()
    {
        // Reload Current Level Scene
        ResumeGame(() =>
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            LoadSceneManager.Instance.LoadSceneAsync(currentSceneIndex);
        });

    }

    public void GameOver()
    {
        // Show GameOver Panel
        GamePanel gamePanel = GamePanel.Instance;
        if(gamePanel != null)
        {
            gamePanel.ShowPanel(GamePanel.PanelTypes.GameOver);
        }
        
    }

    public void EndLevel()
    {
        PauseGame();

        GamePanel gamePanel = GamePanel.Instance;
        if (gamePanel != null)
        {
            LevelManager.Instance.SetResult();
            gamePanel.ShowPanel(GamePanel.PanelTypes.EndLevel);
        }

        UpdateRecord();
        
    }

    public void WinGame()
    {
        
        GamePanel gamePanel = GamePanel.Instance;
        if (gamePanel != null)
        {
            gamePanel.ShowPanel(GamePanel.PanelTypes.Win);
        }
    }


    public void NextLevel()
    {
        int SceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex + 1 >= SceneCount)
        {
            WinGame();
        }
        else
        {
            ResumeGame(() =>
            {
                LoadSceneManager.Instance.LoadSceneAsync(currentSceneIndex + 1);
            });
        }
    }

    #region CallBack

    public void PauseGame()
    {
        if (CurrentGameState == GameState.Pausing) return;
        CurrentGameState = GameState.Pausing;
        Time.timeScale = 0;
    }

    public void ResumeGame(Action callback = null)
    {
        Time.timeScale = 1;
        if(callback != null) callback();
    }

    #endregion

    

}
