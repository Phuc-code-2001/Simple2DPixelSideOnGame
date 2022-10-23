using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{

    public enum PanelTypes
    {
        MainMenu,
        Guide,
        Level,
    }

    [System.Serializable]
    public class PanelDefinition
    {
        public PanelTypes Type;
        public GameObject Prefab;
    }

    [SerializeField] List<PanelDefinition> Panels = new List<PanelDefinition>();

    public GameObject CurrentPanel;

    public void ShowPanel(PanelTypes type)
    {
        HidePanel();
        GameObject panel = Panels.FirstOrDefault(p => p.Type == type)?.Prefab;
        if (panel != null)
        {
            panel.SetActive(true);
            CurrentPanel = panel;
        }
    }

    public void HidePanel()
    {
        if(CurrentPanel != null) CurrentPanel.SetActive(false);
        CurrentPanel = null;
    }

    public void BtnStartClicked()
    {
        // Load Game Scene
        LoadSceneManager loadSceneManager = LoadSceneManager.Instance;
        if(loadSceneManager != null)
        {
            HidePanel();
            loadSceneManager.LoadSceneAsync(1);
        }

    }

    public void BtnLoadLevelClicked()
    {
        ShowPanel(MenuPanel.PanelTypes.Level);
    }

    public void BtnGuideClicked()
    {
        ShowPanel(MenuPanel.PanelTypes.Guide);
    }

    public void BtnExitClicked()
    {
        Application.Quit();
    }

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;
        if(gameManager != null)
        {
            gameManager.CurrentGameState = GameManager.GameState.Menu;
        }
    }
}
