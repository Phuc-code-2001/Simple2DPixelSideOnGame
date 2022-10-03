using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerTrigger : MonoBehaviour
{
    public Platformer platformer;
    public SpriteRenderer sprite;
    public BoxCollider2D trigger;

    private void Start()
    {
        sprite = platformer.GetComponent<SpriteRenderer>();
        Vector2 size = trigger.size;
        size.x = sprite.size.x;
        trigger.size = size;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log($"Detect ..{collider.name}.. is on platform");

        PlatformerChecker platformerChecker = collider.GetComponent<PlatformerChecker>();
        if (platformerChecker != null)
        {
            platformer.ChangeLayer(platformer.TransfromLayer);
            platformerChecker.OnPlatformer = gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // Debug.Log($"Detect ..{collider.name}.. is exit platform");

        PlatformerChecker platformerChecker = collider.GetComponent<PlatformerChecker>();
        if (platformerChecker != null)
        {
            platformer.ChangeLayer(platformer.SelfLayer);
            if (platformerChecker.OnPlatformer == gameObject) platformerChecker.OnPlatformer = null;
        }
    }

}
