using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameStatus
    {
        Pause,
        Playing,
        EndGame,
        Winning,
    }

    public static GameManager Instance;

    public bool IsContinueGame = false;

    public GameStatus gameStatus;

    public string Scene_01 = "Lv_01";

    private void Awake()
    {
        Instance = this;
    }

    public void SaveGame()
    {

    }

    public void LoadMenu()
    {
        SaveGame();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Scene_01);
    }

    public void Continue()
    {
        IsContinueGame = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Transform CanvasPauseGame = transform.Find("CanvasPauseGame");
        if (CanvasPauseGame != null) CanvasPauseGame.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Transform CanvasPauseGame = transform.Find("CanvasPauseGame");
        if (CanvasPauseGame != null) CanvasPauseGame.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

}
