using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePanel : MonoBehaviour
{

    public enum PanelTypes
    {
        Pause,
        Win,
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
        GameObject panel = Panels.FirstOrDefault(p => p.Type == type)?.Prefab;
        if(panel != null) panel.SetActive(true);
        CurrentPanel.SetActive(false);
        CurrentPanel = panel;
    }

    public void HidePanel()
    {
        CurrentPanel?.SetActive(false);
    }

}
