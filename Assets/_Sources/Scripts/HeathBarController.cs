using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour
{
    
    public Vector3 Offset = new Vector3(0.1f, 0.6f, 0);

    public Transform Background;
    public Transform FillBar;

    public float DesignWidth;
    public float DesignHeight;

    public GameObject target;

    private void Start()
    {
        target = transform.parent.gameObject;
        Background = transform.Find("Background");
        DesignWidth = Background.GetComponent<RectTransform>().rect.width;
        DesignHeight = Background.GetComponent<RectTransform>().rect.height;

        FillBar = Background.Find("Fill").GetComponentInChildren<Transform>();
    }

    public void SetHealth(float health, float maxHealth)
    {
        FillBar.localScale = new Vector3(health / maxHealth, 1, 1);
    }

    private void Update()
    {
        Offset = new Vector3(0.1f * target.transform.localScale.x, 0.6f, 0);
        Background.position = target.transform.position + Offset;
        transform.localScale = new Vector2(target.transform.localScale.x == -1 ? -1 : 1, 1);
    }

    private void FixedUpdate()
    {
        IHealthBarHelper healthBarHelper = target.GetComponent<IHealthBarHelper>();
        if(healthBarHelper != null)
        {
            SetHealth(healthBarHelper.GetCurrentHealth(), healthBarHelper.GetMaxHealth());
        }
    }

}
