using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtle : MonoBehaviour
{
    public EnemyController enemyController;

    public float TurtleHeathPoint = 200;
    public float TurtleDamage = 10;
    public float TurtleSpeed = 0.5f;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Start()
    {
        // Configure for enemy
        if (enemyController != null)
        {
            enemyController.enemy.MaxHealthPoint = TurtleHeathPoint;
            enemyController.enemy.HealthPoint = TurtleHeathPoint;
            enemyController.enemy.Damage = TurtleDamage;
            enemyController.enemy.CanFly = false;
            enemyController.enemyMovement.ChangedSpeed = TurtleSpeed;
            enemyController.enemyMovement.DefaultSpeed = TurtleSpeed;
        }
    }
}
