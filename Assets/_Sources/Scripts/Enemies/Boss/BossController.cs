using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public EnemyController enemyController;
    public Animator animator;

    [Header("Properties")]
    public float BossHealthPoint = 1200;
    public float BossDamage = 240;
    public float BossSpeed = 2;

    public GameObject CupObject;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        enemyController.enemy.MaxHealthPoint = BossHealthPoint;
        enemyController.enemy.HealthPoint = BossHealthPoint;
        enemyController.enemy.Damage = BossDamage;
        enemyController.enemy.CanFly = true;
        enemyController.enemyMovement.ChangedSpeed = BossSpeed;
        enemyController.enemyMovement.DefaultSpeed = BossSpeed;
    }

    private void OnDestroy()
    {
        CupObject.SetActive(true);
    }

}
