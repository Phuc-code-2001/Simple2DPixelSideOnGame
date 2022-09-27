using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeAttacker : MonoBehaviour, IAttacker
{
    public EnemyController enemyController;
    public EnemyBee Bee;

    public float AttackAnimateTime = 0.4f;
    public float AttackCoolDown = 2f;

    public GameObject AttackObject;

    public GameObject AttackTo;

    public GameObject DetectedTargetObject;

    public bool CanAttack = true;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        Bee = GetComponent<EnemyBee>();
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
        Bee.animator.SetTrigger("Attack");
        Invoke("AttackAnimationDone", AttackAnimateTime);
        Invoke("AttackDone", AttackCoolDown);
    }

    public void AttackAnimationDone()
    {
        Bee.animator.SetTrigger("Idle");
        SpawnAttackObject();
        enemyController.IsShotting = false;
    }

    public void AttackDone()
    {
        CanAttack = true;
    }

    public void SpawnAttackObject()
    {
        if (AttackObject == null || DetectedTargetObject == null) return;
        GameObject attacker = GameObject.Instantiate(AttackObject, AttackObject.transform.position, Quaternion.identity);
        attacker.SetActive(true);
        attacker.GetComponent<IEnemyBulletMoving>().SetMoveTo(DetectedTargetObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (AttackTo == collider.gameObject)
        {
            Debug.Log($"Bee attacker detected target enter '{collider.name}'");
            if(DetectedTargetObject == null) DetectedTargetObject = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject == DetectedTargetObject)
        {
            Debug.Log($"Bee attacker detected target exit '{collider.name}'");
            DetectedTargetObject = null;
        }
        
    }

}
