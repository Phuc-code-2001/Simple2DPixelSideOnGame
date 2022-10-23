using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    #region Scene Transition Manager

    [SerializeField] private GameObject CanvasLoading;
    [SerializeField] private Slider LoadSlider;
    [SerializeField] private Text LoadText;

    public static LoadSceneManager Instance;

    private void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void LoadSceneAsync(int sceneIndex)
    {
        CanvasLoading.SetActive(true);
        StartCoroutine(LoadingHandler(sceneIndex));
    }

    IEnumerator LoadingHandler(int sceneIndex)
    {
        yield return new WaitUntil(() => CanvasLoading.activeInHierarchy);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        yield return new WaitUntil(() =>
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            LoadSlider.value = progress;
            LoadText.text = (progress * 100).ToString("0") + " %";
            return asyncOperation.isDone;
        });
        
        Reset();
        
    }

    private void Reset()
    {
        LoadSlider.value = 0;
        LoadText.text = "0 %";
        CanvasLoading.SetActive(false);
    }

    #endregion
}
