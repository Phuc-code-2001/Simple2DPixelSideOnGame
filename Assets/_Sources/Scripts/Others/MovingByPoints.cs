using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingByPoints : MonoBehaviour
{
    public GameObject ListPoints;
    public Rigidbody2D rb;

    [SerializeField] protected List<Transform> MovePoints;
    [SerializeField] protected int MovePointIndex = 0;
    [SerializeField] protected Vector2 TargetPosition;

    
    public bool CanMove = false;
    public float DefaultSpeed = 2;
    public float ChangedSpeed = 2;

    protected virtual void Start()
    {
        if (rb == null) throw new Exception($"MovingByPoints of '{name}' missing Rigidbody2D!");
        if (ListPoints == null) throw new Exception($"MovingByPoints of '{name}' missing ListPoints!");
        CanMove = true;
        FindMovePoints();
        TargetPosition = MovePoints[MovePointIndex].position;
    }

    private void FindMovePoints()
    {
        foreach (Transform trans in ListPoints.transform)
        {
            MovePoints.Add(trans);
        }
        if (MovePoints.Count == 0) MovePoints.Add(rb.transform);
    }

    public virtual float GetSpeed()
    {
        return ChangedSpeed;
    }

    protected virtual void Move(float deltaTime)
    {
        Vector2 newPosition = GetNextPosition(deltaTime);
        rb.MovePosition(newPosition);
    }

    protected virtual Vector2 GetNextPosition(float deltaTime)
    {
        return Vector2.MoveTowards(rb.position, TargetPosition, GetSpeed() * deltaTime);
    }

    protected virtual void Update()
    {
        float distance = Vector2.Distance(rb.position, TargetPosition);
        if(distance < 0.05f)
        {
            MovePointIndex = (MovePointIndex + 1) % MovePoints.Count;
            TargetPosition = MovePoints[MovePointIndex].position;
        }
       
    }

    protected virtual void FixedUpdate()
    {
        if (CanMove)
        {
            Move(Time.fixedDeltaTime);
        }
    }

    public void InvokeTargetPosition(Vector2 position)
    {
        TargetPosition = position;
    }

    public void InvokeSpeed(float speed)
    {
        ChangedSpeed = speed;
    }

    public void ResetSpeed()
    {
        ChangedSpeed = DefaultSpeed;
    }
}
