using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    [SerializeField] private GameObject LastGroundedObjectEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Grounded"))
        {
            LastGroundedObjectEnter = collision.gameObject;
            IGroundedHandler groundedHandler = gameObject.GetComponentInParent<IGroundedHandler>();
            groundedHandler.GroundedHandle();
        }
    }

}
