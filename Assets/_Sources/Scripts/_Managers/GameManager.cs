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
        
    }

    public void LoadDatabase()
    {
        Records = SaveGameManager.GetRecords();
    }

    public void SaveGame()
    {
        UpdateRecord();
        SelectedRecord = SaveGameManager.SaveRecord(SelectedRecord, SelectedRecord.Id != 0);
        // Debug.Log(JsonConvert.SerializeObject(SelectedRecord));
    }

    public void UpdateRecord()
    {
        SelectedRecord.MaxLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SelectedRecord.Coin = PlayerController.Instance.playerInfoController.Coin;
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

    private void Start()
    {
        
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
