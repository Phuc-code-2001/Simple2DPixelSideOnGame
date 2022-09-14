using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour, IDamageReceiver
{

    public EnemyController enemyController;
    public Enemy enemy;

    public GameObject EffectObject;

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
            enemyController.IsDeath = true;
        }
        else UseEffect();
    }

    public void UseEffect()
    {
        if(EffectObject != null)
        {
            GameObject effect = GameObject.Instantiate(EffectObject, transform.position, Quaternion.identity, transform);
            effect.SetActive(true);
        }
    }
}
