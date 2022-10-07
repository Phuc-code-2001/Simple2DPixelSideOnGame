using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBee : MonoBehaviour
{

    public EnemyController enemyController;
    public Animator animator;

    [Header("Properties")]
    public float BeeHealthPoint = 200;
    public float BeeDamage = 80;
    public float BeeSpeed = 2;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemyController.enemy.MaxHealthPoint = BeeHealthPoint;
        enemyController.enemy.HealthPoint = BeeHealthPoint;
        enemyController.enemy.Damage = BeeDamage;
        enemyController.enemy.CanFly = true;
        enemyController.enemyMovement.ChangedSpeed = BeeSpeed;
        enemyController.enemyMovement.DefaultSpeed = BeeSpeed;
    }


}
