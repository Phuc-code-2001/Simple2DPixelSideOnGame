using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeAttacker : MonoBehaviour, IAttacker
{
    public EnemyController enemyController;
    public float AttackAnimateTime = 0.4f;

    public float AttackCoolDown = 2f;
    public float AttackTimer = 0;

    public GameObject AttackObject;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Update()
    {
        if (AttackTimer < AttackCoolDown) AttackTimer += Time.deltaTime;
        if(enemyController.IsDetectTarget)
        {
            if(AttackCoolDown - AttackTimer <= 0)
            {
                Attack();
                AttackTimer = 0;
            }
        }
    }

    public void Attack()
    {
        enemyController.IsAttacking = true;
        enemyController.animator.SetTrigger("Attack");

        Invoke("AttackAnimationDone", AttackAnimateTime);
    }

    public void AttackDone()
    {
        enemyController.IsAttacking = false;
    }

    public void AttackHandle()
    {
        if(AttackObject != null)
        {
            GameObject attacker = GameObject.Instantiate(AttackObject, AttackObject.transform.position, Quaternion.identity);
            attacker.GetComponent<IMoveOfSpawnObject>().SetMove();
        }
    }

    public void AttackAnimationDone()
    {
        enemyController.animator.SetTrigger("Idle");
        AttackHandle();
        Invoke("AttackDone", 0.2f);
    }
    



}
