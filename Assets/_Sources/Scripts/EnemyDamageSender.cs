using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDamageSender : DamageSender, IDamageSender
{

    public EnemyController enemyController;

    public List<string> Tags = new List<string>()
    {
        "Player"
    };

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void FixedUpdate()
    {
        Colliders = _colliders.Values.ToList();
        foreach (Collider2D collider in Colliders)
        {
            IDamageReceiver receiver = collider.GetComponent<IDamageReceiver>();
            if (receiver != null && Tags.Contains(collider.tag)) SendDamage(receiver);
        }
    }

    public float GetDamage()
    {
        Enemy enemyEntity = enemyController.enemy;
        return enemyEntity.Damage;
    }

    public void SendDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this);
    }
}
