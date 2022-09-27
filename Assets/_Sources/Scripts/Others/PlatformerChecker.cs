using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerChecker : MonoBehaviour
{

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log("PlatformerChecker trigger enter with: " + collider.name);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log("PlatformerChecker trigger exit with: " + collider.name);

        if (collider.CompareTag("Platformer"))
        {
            Platformer platformer = collider.GetComponent<Platformer>();
            platformer.ChangeLayer(platformer.SelfLayer);
        }
    }
}
