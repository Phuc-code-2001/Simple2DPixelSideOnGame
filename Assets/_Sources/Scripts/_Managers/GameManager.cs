using Assets._Sources.Scripts.SaveAndLoadData;
using Newtonsoft.Json;
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
    public SaveGameManager SaveGameManager = new SaveGameManager();
    public List<Record> Records;
    public Record SelectedRecord;

    public GameState CurrentGameState;
    public GameStartMode StartMode;

    [Header("SubManager")]
    public UIManager UIManager;
    public TimeManager TimeManager;
    public ScenesManager ScenesManager;
    public LevelManager LvManager;
    public SoundManager SoundManager;

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

            UIManager = GetComponent<UIManager>();
            TimeManager = GetComponent<TimeManager>();
            ScenesManager = GetComponent<ScenesManager>();
            LvManager = GetComponent<LevelManager>();
            SoundManager = GetComponentInChildren<SoundManager>();
        }
    }

    public void LoadDatabase()
    {
        Records = SaveGameManager.GetRecords();
    }

    public void SaveGame()
    {

    }

    public void GameOver()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
