using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{

    public enum PanelTypes
    {
        Pause,
        EndLevel,
        GameOver,
        Win,
    }

    [System.Serializable]
    public class PanelDefinition
    {
        public PanelTypes Type;
        public GameObject Prefab;
    }

    public static GamePanel Instance;

    [SerializeField] List<PanelDefinition> Panels = new List<PanelDefinition>();

    public GameObject CurrentPanel;

    public void ShowPanel(PanelTypes type)
    {
        HidePanel();
        GameObject panel = Panels.FirstOrDefault(p => p.Type == type)?.Prefab;
        if(panel != null)
        {
            panel.SetActive(true);
            CurrentPanel = panel;
        }
    }

    public void HidePanel()
    {
        if (CurrentPanel != null) CurrentPanel.SetActive(false);
        CurrentPanel = null;
    }


    public void PauseButtonClicked()
    {
        ShowPanel(PanelTypes.Pause);

        GameManager gameManager = GameManager.Instance;
        if(gameManager != null)
        {
            gameManager.PauseGame();
        }

    }

    public void ResumeButtonClicked()
    {
        HidePanel();
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            gameManager.ResumeGame(() =>
            {
                gameManager.CurrentGameState = GameManager.GameState.Playing;
            });
        }

    }

    public void BackMenuButtonClicked()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            gameManager.ResumeGame(() =>
            {
                gameManager.CurrentGameState = GameManager.GameState.Menu;
                // Load Menu Scene
                LoadSceneManager loadSceneManager = LoadSceneManager.Instance;
                if(loadSceneManager != null)
                {
                    loadSceneManager.LoadSceneAsync(0);
                }
            });
        }
    }

    public void NextButtonClicked()
    {
        GameManager gameManager = GameManager.Instance;
        if(gameManager != null)
        {
            gameManager.NextLevel();
        }
    }

    public void RestartButtonClicked()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            gameManager.Restart();
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            gameManager.CurrentGameState = GameManager.GameState.Playing;
        }
    }
}
