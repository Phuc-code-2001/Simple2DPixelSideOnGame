using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour, IDeathHandler
{

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public Enemy enemy;
    public EnemyMovement enemyMovement;

    [Header("Effects")]
    public GameObject DeathEffect;
    public GameObject HitEffect;

    [Header("Status")]
    public bool IsDeath = false;
    public bool IsJumping = false;
    public bool IsAttacking = false;
    public bool IsDetectTarget = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        enemy = GetComponent<Enemy>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        if(PlayerController.Instance != null) Physics2D.IgnoreLayerCollision(PlayerController.Instance.gameObject.layer, gameObject.layer);
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    private void Update()
    {
        if(IsDeath) Death();
    }

    public void Hit()
    {
        if (HitEffect != null) UseHitEffect();
    }

    public void UseHitEffect()
    {
        HitEffect.SetActive(true);
        GameObject effect = GameObject.Instantiate(HitEffect, transform.position, Quaternion.identity, transform);
        HitEffect.SetActive(false);
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
            DeathEffect.SetActive(true);
            GameObject effect = GameObject.Instantiate(DeathEffect, transform.position, Quaternion.identity);
            DeathEffect.SetActive(false);
        }
    }
}
