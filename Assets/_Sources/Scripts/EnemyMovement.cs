using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Components")]
    public EnemyController enemyController;
    public Rigidbody2D rb;

    [Header("Area")]
    public Transform LeftPoint;
    public Transform RightPoint;

    [Header("Properties")]
    public float velocity = 1f;

    [SerializeField] private Transform TargetPoint;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyController = GetComponentInParent<EnemyController>();
        LeftPoint = enemyController.transform.Find("LeftPoint");
        RightPoint = enemyController.transform.Find("RightPoint");
    }

    private void Start()
    {
        TargetPoint = LeftPoint;
    }

    private void Update()
    {
        if(transform.position.x <= LeftPoint.position.x)
        {
            TargetPoint = RightPoint;
        }

        if(transform.position.x >= RightPoint.position.x)
        {
            TargetPoint = LeftPoint;
        }
    }

    private void FixedUpdate()
    {
        if(!enemyController.IsDeath)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPoint.position, velocity * Time.fixedDeltaTime);
            PlayFacing();
        }
    }

    private void PlayFacing()
    {
        if(TargetPoint == LeftPoint)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
