using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Components")]
    public Rigidbody2D rb;
    public EnemyDamageSender enemyDamageSender;

    [Header("Children")]
    public Enemy enemy;

    public bool IsDeath = false;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
        enemy = GetComponentInChildren<Enemy>();
    }

    public void Death(float delay = 0)
    {
        Destroy(gameObject, delay);
    }
}
