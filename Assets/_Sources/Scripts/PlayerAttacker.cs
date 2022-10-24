using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttacker : MonoBehaviour, IAttacker
{

    private PlayerController playerController;

    [SerializeField] private float AttackAnimateTime = .8f;
    [SerializeField] private float AttackCoolDown = 1.2f;
    [SerializeField] private bool CanAttack = true;

    [SerializeField] private float DelayTimeHandle = 0.6f;
    [SerializeField] private GameObject AttackObject;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(playerController.inputController.AttackSignalActive && CanAttack && !playerController.IsDeath)
        {
            Attack();
        }
    }

    private float startAttackAt;
    public void Attack()
    {
        playerController.IsAttacking = true;
        CanAttack = false;
        startAttackAt = Time.time;
        StartCoroutine(AttackHandle());
        playerController.playerAudioController.PlaySwordAttackSound();
    }

    IEnumerator AttackHandle()
    {
        yield return new WaitUntil(() => Time.time - startAttackAt >= DelayTimeHandle);
        SpawnObject();
        yield return new WaitUntil(() => Time.time - startAttackAt >= AttackAnimateTime);
        playerController.IsAttacking = false;
        yield return new WaitUntil(() => Time.time - startAttackAt >= AttackCoolDown);
        AttackDone();
    }

    public void AttackDone()
    {
        CanAttack = true;
        playerController.inputController.AttackSignalActive = false;
    }

    private void SpawnObject()
    {
        if(Interrupted)
        {
            AttackDone();
        }
        else if (AttackObject != null)
        {
            AttackObject.SetActive(true);
        }
    }

    private bool Interrupted => playerController.IsHitting || playerController.IsDeath;

}
