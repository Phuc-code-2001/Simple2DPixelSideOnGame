using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerChecker : MonoBehaviour
{

    public GameObject Parent;
    public GameObject OnPlatformer;

    private void Awake()
    {
        Parent = transform.parent.gameObject;  
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log("PlatformerChecker trigger exit with: " + collider.name);
        if (collider.CompareTag("Platformer"))
        {
            IGroundedHandler GroundedHandler = Parent.GetComponent<IGroundedHandler>();
            GroundedHandler.NonGroundedHandle();
        }
    }
}
