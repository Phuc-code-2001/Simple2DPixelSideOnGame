using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SmoothFollower : MonoBehaviour, IFollower
{
    public Transform TopLeft;
    public Transform BottomRight;

    public GameObject Follower;
    public GameObject TargetObject;
    public Vector2 FollowerOffset;
    public float Speed;

    public void Follow(float deltaTime)
    {

        float calculatedSpeed = Mathf.Max(TargetObject.GetComponent<Rigidbody2D>().velocity.magnitude, Speed);
        Vector3 newPosition = TargetObject.transform.position + new Vector3(FollowerOffset.x, FollowerOffset.y, Follower.transform.position.z);

        if(TopLeft != null && BottomRight != null)
        {
            IRect rect = Follower.GetComponent<IRect>();
            newPosition.x = Mathf.Max(newPosition.x, TopLeft.position.x + rect.GetWidth());
            newPosition.x = Mathf.Min(newPosition.x, BottomRight.position.x - rect.GetWidth());

            newPosition.y = Mathf.Max(newPosition.y, BottomRight.position.y + rect.GetHeight());
            newPosition.y = Mathf.Min(newPosition.y, TopLeft.position.y - rect.GetHeight());
        }


        Follower.transform.position = Vector3.MoveTowards(Follower.transform.position, newPosition, calculatedSpeed * deltaTime);
    }

    
}
