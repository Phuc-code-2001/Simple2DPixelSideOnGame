using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerChecker : MonoBehaviour, IMoveWithPlatformer
{

    public GameObject Parent;
    public GameObject OnPlatformer;

    public bool IsMovingWithPlatformer;
    public Vector2 MovingDirector;

    private void Awake()
    {
        Parent = transform.parent.gameObject;  
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.CompareTag("Platformer"))
        {
            IGroundedHandler GroundedHandler = Parent.GetComponent<IGroundedHandler>();
            GroundedHandler.NonGroundedHandle();

            MovingPlatform movingPlatform = collider.GetComponentInParent<MovingPlatform>();
            if (movingPlatform != null)
            {
                // Debug.Log("PlatformerChecker detected trigger exit with " + movingPlatform.gameObject.name);
                LeaveMovingPlatformer(movingPlatform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Platformer platformer = collision.GetComponent<Platformer>();
        if(platformer != null)
        {
            
            MovingPlatform movingPlatform = platformer.GetComponentInParent<MovingPlatform>();
            if(movingPlatform != null)
            {
                // Debug.Log("PlatformerChecker detected trigger with " + movingPlatform.gameObject.name);
                InvokeMovingPlatformer(movingPlatform);
            }

        }
    }

    public void InvokeMovingPlatformer(MovingPlatform movingPlatform)
    {
        // Parent.transform.SetParent(platformer.rb.transform);

        if (movingPlatform.ObjectsMoveTogether.Contains(gameObject)) return;
        movingPlatform.ObjectsMoveTogether.Add(gameObject);
    }

    public void LeaveMovingPlatformer(MovingPlatform movingPlatform)
    {
        if (movingPlatform.ObjectsMoveTogether.Contains(gameObject))
        {
            movingPlatform.ObjectsMoveTogether.Remove(gameObject);
        }
    }

    public void MoveByVelocity(Vector2 director)
    {
        PlayerController controller = Parent.GetComponent<PlayerController>();
        if(controller != null)
        {
            if(!controller.IsMoveLeft && !controller.IsMoveRight)
            {
                controller.rb.velocity = new Vector2(director.x, controller.rb.velocity.y);
            }
        }
    }
}
