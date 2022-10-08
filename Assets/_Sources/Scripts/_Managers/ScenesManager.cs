using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public int CurrentSceneIndex = 0;
    public int NumberOfScenes;

    private void Awake()
    {
        NumberOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    public void LoadScene(int sceneIndex)
    {
        var loadSceneProcess = SceneManager.LoadSceneAsync(sceneIndex);
        // Show Loadding

        CurrentSceneIndex = sceneIndex;
    }

    public void LoadNextScene()
    {
        LoadScene(CurrentSceneIndex + 1);
    }
}
