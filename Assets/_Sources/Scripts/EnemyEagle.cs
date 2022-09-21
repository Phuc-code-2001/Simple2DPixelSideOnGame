using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : MonoBehaviour
{
    public EnemyController enemyController;

    public float EagleHeathPoint = 100;
    public float EagleDamage = 20;
    public float Speed = 2;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Start()
    {
        if (enemyController != null)
        {
            enemyController.enemy.MaxHealthPoint = EagleHeathPoint;
            enemyController.enemy.HealthPoint = EagleHeathPoint;
            enemyController.enemy.Damage = EagleDamage;
            enemyController.enemyMovement.velocity = Speed;
        }
    }
}
