using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{

    public GameObject Checker;
    public string SelfLayer;
    public string TransfromLayer = "Ground";

    public string CurrentLayer;

    private void Start()
    {
        SelfLayer = "Platformer";
        ChangeLayer(SelfLayer);
    }

    public void ChangeLayer(string layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
        CurrentLayer = layerName;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log($"Detect ..{collider.name}.. is on platform");

        if(collider.gameObject.layer == Checker.layer)
        {
            ChangeLayer(TransfromLayer);
        }

    }

}
