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
    public Vector2 FollowerOffset = new Vector2(2, 1);
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
        Vector3 newPosition = TargetObject.transform.position + new Vector3(FollowerOffset.x, FollowerOffset.y, transform.position.z);

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
