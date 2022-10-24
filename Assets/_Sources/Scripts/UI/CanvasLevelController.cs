using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLevelController : MonoBehaviour
{
    [SerializeField] Button[] BtnList;

    [SerializeField] Sprite LockSprite;

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        foreach (var b in BtnList)
        {
            int sceneIndex = Int32.Parse(b.gameObject.name);

            if (sceneIndex <= GameManager.Instance.SelectedRecord.MaxLevelIndex)
            {
                b.onClick.AddListener(() =>
                {
                    LoadSceneManager loadSceneManager = LoadSceneManager.Instance;
                    if (loadSceneManager != null)
                    {
                        loadSceneManager.LoadSceneAsync(sceneIndex);
                    }

                });
            }
            else
            {
                Text text = b.GetComponentInChildren<Text>();
                text.text = "";
                Image image = text.GetComponentInChildren<Image>(true);
                image.gameObject.SetActive(true);
                b.interactable = false;
            }

        }
    }

    private void OnEnable()
    {
        LoadLevel();
    }

}
