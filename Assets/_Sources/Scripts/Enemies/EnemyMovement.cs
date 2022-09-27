using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MovingByPoints
{
    [Header("Components")]
    public EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    protected override void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        PlayFacing();
    }

    protected override void FixedUpdate()
    {
        if (enemyController.IsDeath || enemyController.IsShotting)
        {
            CanMove = false;
        }
        else
        {
            CanMove = true;
        }
        base.FixedUpdate();
    }

    private void PlayFacing()
    {
        float dx = TargetPosition.x - rb.position.x;
        if(dx < 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
