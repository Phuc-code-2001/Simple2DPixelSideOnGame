using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public string NameOfGroundLayer = "Ground";
    public int GroundLayerIndex;
    public GameObject Parent;

    private void Awake()
    {
        GroundLayerIndex = LayerMask.NameToLayer(NameOfGroundLayer);
        Parent = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndexCollider = collision.transform.gameObject.layer;
        if(layerIndexCollider == GroundLayerIndex)
        {
            IGroundedHandler GroundedHandler = Parent.GetComponent<IGroundedHandler>();
            GroundedHandler.GroundedHandle();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int layerIndexCollider = collision.transform.gameObject.layer;
        if (layerIndexCollider == GroundLayerIndex)
        {
            IGroundedHandler GroundedHandler = Parent.GetComponent<IGroundedHandler>();
            GroundedHandler.NonGroundedHandle();
        }
    }

}
