using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string Scene_01 = "Lv_01";

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Scene_01);
    }

    public void Continue()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

}
