using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBee : MonoBehaviour
{
    [Header("Properties")]
    public float BeeHealthPoint = 100;
    public float BeeDamage = 50;

    public EnemyController enemyController;

    public string AttackToTag = "Player";

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Start()
    {
        enemyController.enemy.MaxHealthPoint = BeeHealthPoint;
        enemyController.enemy.HealthPoint = BeeHealthPoint;
        enemyController.enemy.Damage = BeeDamage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(AttackToTag))
        {
            Debug.Log($"Detected target...{collision.name}");
            enemyController.IsDetectTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(AttackToTag))
        {
            Debug.Log($"Detected target exit...{collision.name}");
            enemyController.IsDetectTarget = false;
        }
    }

}
