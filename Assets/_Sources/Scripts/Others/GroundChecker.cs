using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public string NameOfGroundLayer = "Ground";
    public int GroundLayerIndex;
    public GameObject Parent;

    public GameObject OnGround;

    private void Awake()
    {
        GroundLayerIndex = LayerMask.NameToLayer(NameOfGroundLayer);
        Parent = transform.parent.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        int layerIndexCollider = collision.gameObject.layer;
        if(layerIndexCollider == GroundLayerIndex)
        {
            IGroundedHandler GroundedHandler = Parent.GetComponent<IGroundedHandler>();
            GroundedHandler.GroundedHandle();
            OnGround = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int layerIndexCollider = collision.gameObject.layer;
        if (layerIndexCollider == GroundLayerIndex)
        {
            IGroundedHandler GroundedHandler = Parent.GetComponent<IGroundedHandler>();
            GroundedHandler.NonGroundedHandle();
            OnGround = null;
        }
    }

}
