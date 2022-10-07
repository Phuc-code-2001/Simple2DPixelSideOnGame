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

            GameManager.Instance.ScenesManager.LoadScene(1);
            GameManager.Instance.CurrentGameState = GameManager.GameState.Playing;
            GameManager.Instance.StartMode = GameManager.GameStartMode.NewGame;

            GameManager.Instance.UIManager.OnPlayUI();
        }
        else
        {
            Debug.LogWarning("StartGame: Scene not found");
        }
    }

    public void Continue()
    {
        GameManager.Instance.StartMode = GameManager.GameStartMode.ContinueGame;
        GameManager.Instance.LoadDatabase();
        // Show Continue Menu
    }

    public void LoadMenu()
    {
        GameManager.Instance.SaveGame();
        GameManager.Instance.ScenesManager.LoadScene(0);
        GameManager.Instance.UIManager.LoadMenu();
        GameManager.Instance.TimeManager.ResumeTime();
    }
}