using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpossum : MonoBehaviour
{
    public EnemyController enemyController;

    public float OpposumHeathPoint = 200;
    public float OpposumDamage = 10;
    public float OpposumSpeed = 1;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Start()
    {
        if(enemyController != null)
        {
            enemyController.enemy.MaxHealthPoint = OpposumHeathPoint;
            enemyController.enemy.HealthPoint = OpposumHeathPoint;
            enemyController.enemy.Damage = OpposumDamage;
            enemyController.enemyMovement.EnemySpeed = OpposumSpeed;
            enemyController.enemyMovement.DefaultSpeed = OpposumSpeed;
        }
    }

}
