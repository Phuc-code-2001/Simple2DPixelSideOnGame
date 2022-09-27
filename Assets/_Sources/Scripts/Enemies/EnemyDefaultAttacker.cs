using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Attach to plugin enemy to implement attacker default
/// </summary>
public class EnemyDefaultAttacker : MonoBehaviour, IAttacker, IDamageSender
{

    public EnemyController enemyController;

    public float AttackAnimateTime = 0.5f;
    public float AttackCoolDown = 2f;

    public GameObject DetectedTargetObject;

    public GameObject AttackTo;

    public bool CanAttack = true;

    [Header("Debug")]
    public float _Distance;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void Start()
    {
        AttackTo = PlayerController.Instance.gameObject;
    }

    public float GetDamage()
    {
        return enemyController.enemy.Damage;
    }

    public void SendDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this);
    }

    private void Update()
    {
        Attack();
        CheckToSendDamage();
    }

    public void Attack()
    {
        if (DetectedTargetObject == null || enemyController.IsAttacking || !CanAttack) return;
        CanAttack = false;
        enemyController.IsAttacking = true;

        enemyController.enemyMovement.InvokeSpeed(10);
        Transform enemyTarget = DetectedTargetObject.transform.Find("EnemyTarget");
        Vector2 t_position = new Vector2()
        {
            x = enemyTarget.position.x,
            y = enemyController.enemy.CanFly ? enemyTarget.position.y : enemyController.rb.position.y
        };
        enemyController.enemyMovement.InvokeTargetPosition(t_position);

        Invoke("AttackAnimationDone", AttackAnimateTime);
        Invoke("AttackDone", AttackCoolDown);
    }

    public void AttackAnimationDone()
    {
        enemyController.IsAttacking = false;
        enemyController.enemyMovement.ResetSpeed();
    }

    public void AttackDone()
    {
        CanAttack = true;
    }

    public void CheckToSendDamage()
    {
        float distance = Vector2.Distance(transform.position, AttackTo.transform.position);
        _Distance = distance;
        if (enemyController.IsAttacking && distance <= 1f)
        {
            IDamageReceiver damageReceiver = AttackTo.GetComponent<IDamageReceiver>();
            if(damageReceiver != null) SendDamage(damageReceiver);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (AttackTo == collider.gameObject)
        {
            if (DetectedTargetObject == null) DetectedTargetObject = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == DetectedTargetObject)
        {
            DetectedTargetObject = null;
        }

    }

    
}
