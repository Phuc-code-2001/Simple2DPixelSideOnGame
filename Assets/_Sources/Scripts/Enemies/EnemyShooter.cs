using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour, IAttacker
{
    public EnemyController enemyController;
    public Animator animator;

    public float AttackAnimateTime = 0.4f;
    public float AttackCoolDown = 2f;

    public GameObject Bullet;

    public GameObject AttackTo;

    public GameObject DetectedTargetObject;

    public bool CanAttack = true;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        AttackTo = PlayerController.Instance.gameObject;
    }

    private void FixedUpdate()
    {
        Attack();
    }

    public void Attack()
    {
        if (DetectedTargetObject == null || enemyController.IsShotting || !CanAttack) return;
        enemyController.IsShotting = true;
        CanAttack = false;
        animator.SetTrigger("Attack");
        Invoke("AttackAnimationDone", AttackAnimateTime);
        Invoke("AttackDone", AttackCoolDown);
    }

    public void AttackAnimationDone()
    {
        animator.SetTrigger("Idle");
        SpawnAttackObject();
        enemyController.IsShotting = false;
    }

    public void AttackDone()
    {
        CanAttack = true;
    }

    public void SpawnAttackObject()
    {
        if (Bullet == null || DetectedTargetObject == null) return;

        GameObject bullet = GameObject.Instantiate(Bullet, Bullet.transform.position, Quaternion.identity);
        
        Transform enemyTarget = DetectedTargetObject.transform.Find("EnemyTarget");
        if(enemyTarget != null)
        {
            bullet.GetComponent<IEnemyBulletMoving>().SetMoveTo(enemyTarget.gameObject);
        }
        else
        {
            bullet.GetComponent<IEnemyBulletMoving>().SetMoveTo(DetectedTargetObject);
        }
        EnemyBulletDamageSender enemyBulletDamageSender = bullet.GetComponent<EnemyBulletDamageSender>();
        if (enemyBulletDamageSender != null) enemyBulletDamageSender.Damage = enemyController.enemy.Damage;
        bullet.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (AttackTo == collider.gameObject)
        {
            if(DetectedTargetObject == null) DetectedTargetObject = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject == DetectedTargetObject)
        {
            DetectedTargetObject = null;
        }
        
    }

}
