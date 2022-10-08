using Assets._Sources.Scripts.SaveAndLoadData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if (GameManager.Instance.ScenesManager.NumberOfScenes > 1)
        {
            // Start a new save record
            GameManager.Instance.SelectedRecord = new Record();

            GameManager.Instance.CurrentGameState = GameManager.GameState.Playing;
            GameManager.Instance.StartMode = GameManager.GameStartMode.NewGame;

            GameManager.Instance.UIManager.OnPlayUI();
            GameManager.Instance.ScenesManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("StartGame: Scene not found");
        }
    }

    public void Continue()
    {
        GameManager.Instance.LoadDatabase();

        if (GameManager.Instance.Records.Count > 0)
        {
            // Show Continue Menu

            int SceneIndex = GameManager.Instance.SelectedRecord.SceneIndex;
            GameManager.Instance.CurrentGameState = GameManager.GameState.Playing;
            GameManager.Instance.StartMode = GameManager.GameStartMode.ContinueGame;

            GameManager.Instance.UIManager.OnPlayUI();
            GameManager.Instance.ScenesManager.LoadScene(SceneIndex);
        }
        else 
        { 
            StartGame();
        }

    }

    public void LoadMenu()
    {
        GameManager.Instance.SaveGame();
        GameManager.Instance.ScenesManager.LoadScene(0);
        GameManager.Instance.UIManager.LoadMenu();
        GameManager.Instance.TimeManager.ResumeTime();
    }
}