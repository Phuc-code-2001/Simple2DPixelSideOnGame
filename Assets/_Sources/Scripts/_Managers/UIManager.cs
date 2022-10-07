using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas UI")]
    public GameObject MenuUI;
    public GameObject PauseUI;
    public GameObject SetupUI;

    public void LoadMenu()
    {
        MenuUI.SetActive(true);
        SetupUI.SetActive(false);
        PauseUI.SetActive(false);
    }

    public void OnPlayUI()
    {
        MenuUI.SetActive(false);
        SetupUI.SetActive(true);
        PauseUI.SetActive(false);

    }
}
