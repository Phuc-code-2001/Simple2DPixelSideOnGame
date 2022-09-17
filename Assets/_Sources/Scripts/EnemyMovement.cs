using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Components")]
    public EnemyController enemyController;


    [Header("Properties")]
    public float velocity = 1f;
    [SerializeField] private List<Transform> MovePoints;
    [SerializeField] private int movePointIndex = 0;

    [SerializeField] private Transform TargetPoint;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        FindMovePoints();
        TargetPoint = MovePoints.Count == 0 ? transform : MovePoints[movePointIndex];
    }

    private void FindMovePoints()
    {
        Transform points = transform.parent.Find("MovePoints");
        foreach (Transform point in points) MovePoints.Add(point);
    }

    private void Update()
    {
        float gap = Vector2.Distance(transform.position, TargetPoint.position);
        if(gap < 0.05f)
        {
            movePointIndex = (movePointIndex + 1) % MovePoints.Count;
            TargetPoint = MovePoints[movePointIndex];
        }
    }

    private void FixedUpdate()
    {
        if (!enemyController.IsDeath)
        {
            // transform.position = Vector3.MoveTowards(transform.position, TargetPoint.position, velocity * Time.fixedDeltaTime);
            enemyController.rb.MovePosition(Vector3.MoveTowards(transform.position, TargetPoint.position, velocity * Time.fixedDeltaTime));
            PlayFacing();
        }
    }

    private void PlayFacing()
    {
        Vector2 direction = TargetPoint.position - transform.position;
        if(direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
