using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MovingByPoints
{
    protected override void Start()
    {
        if(rb == null) rb = transform.Find("Platformer")?.GetComponent<Rigidbody2D>();
        if(ListPoints == null) ListPoints = transform.Find("MovePoints").gameObject;
        base.Start();
    }
}
