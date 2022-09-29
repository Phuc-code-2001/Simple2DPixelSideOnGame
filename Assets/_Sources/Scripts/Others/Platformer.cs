using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{

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
        //Debug.Log($"Detect ..{collider.name}.. is on platform");

        PlatformerChecker platformerChecker = collider.GetComponent<PlatformerChecker>();
        if(platformerChecker != null)
        {
            ChangeLayer(TransfromLayer);
            platformerChecker.OnPlatformer = gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log($"Detect ..{collider.name}.. is exit platform");

        PlatformerChecker platformerChecker = collider.GetComponent<PlatformerChecker>();
        if (platformerChecker != null)
        {
            ChangeLayer(SelfLayer);
            if(platformerChecker.OnPlatformer == gameObject) platformerChecker.OnPlatformer = null;
        }
    }



}
