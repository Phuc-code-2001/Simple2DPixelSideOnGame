using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyController : MonoBehaviour, IDeathHandler
{

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public Enemy enemy;
    public EnemyMovement enemyMovement;
    public EnemySpawnCollector enemySpawnCollector;

    [Header("Effects")]
    public GameObject DeathEffect;
    public GameObject HitEffect;

    [Header("Status")]
    public bool IsDeath = false;
    public bool IsJumping = false;
    public bool IsShotting = false;

    public bool IsAttacking = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemySpawnCollector = GetComponent<EnemySpawnCollector>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if(PlayerController.Instance != null) Physics2D.IgnoreLayerCollision(PlayerController.Instance.gameObject.layer, gameObject.layer);
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    public void Hit()
    {
        if (IsDeath) return;
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
        if (IsDeath) return;
        IsDeath = true;
        UseDeathEffect();

        enemySpawnCollector.SpawnItems();
        StartCoroutine(CalculatePoint());
        Destroy(transform.parent.gameObject);
    }

    private void UseDeathEffect()
    {
        if(DeathEffect != null)
        {
            GameObject effect = GameObject.Instantiate(DeathEffect, transform.position, Quaternion.identity);
            effect.SetActive(true);
        }
    }

    private IEnumerator CalculatePoint()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LvManager.EnemyKilled();
        }
        yield return null;
    }
}
