using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRino : MonoBehaviour
{
    public EnemyController enemyController;
    public Animator animator;

    [Header("Properties")]
    public float RinoHealthPoint = 200;
    public float RinoDamage = 120;
    public float RinoSpeed = 1;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemyController.enemy.MaxHealthPoint = RinoHealthPoint;
        enemyController.enemy.HealthPoint = RinoHealthPoint;
        enemyController.enemy.Damage = RinoDamage;
        enemyController.enemy.CanFly = false;
        enemyController.enemyMovement.ChangedSpeed = RinoSpeed;
        enemyController.enemyMovement.DefaultSpeed = RinoSpeed;
    }
}
