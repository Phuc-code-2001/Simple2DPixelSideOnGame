using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour
{

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public Enemy enemy;
    public EnemyMovement enemyMovement;

    [Header("Effects")]
    public GameObject DeathEffect;

    [Header("Status")]
    public bool IsDeath = false;
    public bool IsJumping = false;
    public bool IsAttacking = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        enemy = GetComponent<Enemy>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if(IsDeath) Death();
    }

    public void Attack(Transform target)
    {

    }

    public void Death()
    {
        UseDeathEffect();
        Destroy(transform.parent.gameObject);
    }

    private void UseDeathEffect()
    {
        if(DeathEffect != null)
        {
            GameObject effect = GameObject.Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }
    }
}
