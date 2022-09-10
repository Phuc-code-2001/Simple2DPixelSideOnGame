using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : MonoBehaviour, IDamageReceiver
{

    public EnemyController enemyController;
    public Animator animator;
    public Enemy enemy;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    public void ReceiveDamage(IDamageSender sender)
    {
        enemy.ReceiveDamage(sender.GetDamage());
        UseEffect();
    }

    public void UseEffect()
    {
        if(enemy.IsDeath())
        {
            animator.SetTrigger("death");
            enemyController.IsDeath = true;
        }
        else
        {
            enemyController.rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(enemyController.IsDeath)
        {
            float delay = animator.GetCurrentAnimatorStateInfo(0).length;
            enemyController.Death(delay);
        }
    }
}
