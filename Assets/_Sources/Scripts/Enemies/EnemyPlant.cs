using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant : MonoBehaviour
{
    public EnemyController enemyController;
    public Animator animator;

    [Header("Properties")]
    public float PlantHealthPoint = 200;
    public float PlantDamage = 120;
    public float PlantSpeed = 0;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemyController.enemy.MaxHealthPoint = PlantHealthPoint;
        enemyController.enemy.HealthPoint = PlantHealthPoint;
        enemyController.enemy.Damage = PlantDamage;
        enemyController.enemy.CanFly = false;
        enemyController.enemyMovement.ChangedSpeed = PlantSpeed;
        enemyController.enemyMovement.DefaultSpeed = PlantSpeed;
    }
}
