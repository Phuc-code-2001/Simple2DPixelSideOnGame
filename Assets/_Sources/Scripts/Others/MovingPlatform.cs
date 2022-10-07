using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MovingByPoints
{

    public List<GameObject> ObjectsMoveTogether;
    public GameObject platformer;

    protected override void Start()
    {
        if(rb == null) rb = transform.Find("Platformer")?.GetComponent<Rigidbody2D>();
        if(ListPoints == null) ListPoints = transform.Find("MovePoints").gameObject;
        base.Start();
    }

    protected override void Move(float deltaTime)
    {

        Vector2 director = (GetNextPosition(deltaTime) - rb.position) * (1 / deltaTime);

        foreach(var mover in ObjectsMoveTogether)
        {
            IMoveWithPlatformer moveWith = mover.GetComponent<IMoveWithPlatformer>();
            if(moveWith != null)
            {
                moveWith.MoveByVelocity(director);
            }
        }

        base.Move(deltaTime);
    }

    
}
