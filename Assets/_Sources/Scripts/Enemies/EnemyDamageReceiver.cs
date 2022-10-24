using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour, IDamageReceiver
{

    public EnemyController enemyController;
    public Enemy enemy;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        enemy = GetComponent<Enemy>();
    }

    public void ReceiveDamage(IDamageSender sender)
    {
        enemy.ReceiveDamage(sender.GetDamage());
        if (enemy.IsDeath())
        {
            enemyController.Death();
        }
        else
        {
            enemyController.Hit();
        }

    }
    
}
