using Assets._Sources.Scripts.SaveAndLoadData;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        SelectedRecord = Records.FirstOrDefault();

        // Debug.Log(JsonConvert.SerializeObject(SelectedRecord));
    }

    public void SaveGame()
    {
        UpdateRecord();
        SelectedRecord = SaveGameManager.SaveRecord(SelectedRecord, SelectedRecord.Id != 0);
        Debug.Log(JsonConvert.SerializeObject(SelectedRecord));
    }

    public void UpdateRecord()
    {
        SelectedRecord.SceneIndex = ScenesManager.CurrentSceneIndex;

        SelectedRecord.Player.HeathPoint = PlayerController.Instance.playerInfoController.HealthPoint;
        SelectedRecord.Player.ManaPoint = PlayerController.Instance.playerInfoController.ManaPoint;
        SelectedRecord.Player.Coin = PlayerController.Instance.playerInfoController.Coin;
        
        // SelectedRecord.PositionX = PlayerController.Instance.rb.position.x;
        // SelectedRecord.PositionY = PlayerController.Instance.rb.position.y;
    }

    public void GameOver()
    {
        PlayerController.Instance?.Reload();
    }

    public void EndLevel()
    {
        UIManager.ShowEndLevel();
        LvManager.Finish();
        CurrentGameState = GameState.Ending;
        TimeManager.PauseTime();
        // SaveGame();
    }

    public void WinGame()
    {

    }

    public void Restart()
    {
        CurrentGameState = GameState.Playing;
        TimeManager.ResumeTime();
        UIManager.OnPlayUI();
        LvManager.Reset();
        ScenesManager.LoadScene(ScenesManager.CurrentSceneIndex);
    }

    public void NextLevel()
    {
        CurrentGameState = GameState.Playing;
        TimeManager.ResumeTime();
        UIManager.OnPlayUI();
        LvManager.Reset();
        ScenesManager.LoadNextScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
