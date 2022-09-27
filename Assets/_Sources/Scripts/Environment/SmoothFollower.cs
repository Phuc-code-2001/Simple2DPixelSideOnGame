using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SmoothFollower : MonoBehaviour, IFollower
{
    public Transform TopLeft;
    public Transform BottomRight;

    public GameObject TargetObject;

    [Header("Properties")]
    public Vector2 FollowerOffset = new Vector2(2, 3);
    public float Speed = 4;

    [Header("Calculated Fields")]
    [SerializeField] protected Vector3 targetFollowerPosition;

    public void Follow(float deltaTime)
    {
        float calculatedSpeed = Mathf.Max(TargetObject.GetComponent<Rigidbody2D>().velocity.magnitude, Speed);
        transform.position = Vector3.MoveTowards(transform.position, targetFollowerPosition, calculatedSpeed * deltaTime);
    }

    public Vector3 GetNewPosition()
    {
        float x = TargetObject.transform.position.x + FollowerOffset.x;
        float y = TargetObject.transform.position.y + FollowerOffset.y;
        float z = -10;
        Vector3 newPosition = new Vector3(x, y, z);

        if (TopLeft != null && BottomRight != null)
        {
            IRect rect = GetComponent<IRect>();
            newPosition.x = Mathf.Max(newPosition.x, TopLeft.position.x + rect.GetWidth());
            newPosition.x = Mathf.Min(newPosition.x, BottomRight.position.x - rect.GetWidth());

            newPosition.y = Mathf.Max(newPosition.y, BottomRight.position.y + rect.GetHeight());
            newPosition.y = Mathf.Min(newPosition.y, TopLeft.position.y - rect.GetHeight());
        }

        return newPosition;
    }

    
}
