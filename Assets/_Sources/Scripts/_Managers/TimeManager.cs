using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

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
        GameManager.Instance.UIManager.PauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        ResumeTime();
        GameManager.Instance.UIManager.PauseUI.SetActive(false);
    }
}
