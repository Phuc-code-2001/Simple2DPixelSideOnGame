using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : MonoBehaviour
{
    public EnemyController enemyController;

    public float EagleHeathPoint = 300;
    public float EagleDamage = 50;
    public float EagleSpeed = 3;

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
            enemyController.enemy.CanFly = true;
            enemyController.enemyMovement.ChangedSpeed = EagleSpeed;
            enemyController.enemyMovement.DefaultSpeed = EagleSpeed;
        }
    }
}
