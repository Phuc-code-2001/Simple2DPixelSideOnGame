using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttacker : MonoBehaviour, IAttacker
{

    public PlayerController playerController;

    public float AttackAnimateTime = 1.0f;
    public float AttackCoolDown = 1.5f;

    public float DelayTimeHandle = 0.6f;
    public GameObject AttackObject;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        AttackObject = transform.Find("SwordAttack").gameObject;
    }

    private void Update()
    {
        if(playerController.inputController.AttackSignalActive && !playerController.IsAttacking)
        {
            Attack();
            Invoke("AttackReset", AttackCoolDown);
        }
    }

    public void AttackReset()
    {
        playerController.inputController.AttackSignalActive = false;
        playerController.IsAttacking = false;
    }

    public void Attack()
    {
        playerController.IsAttacking = true;
        Invoke("AttackHandler", DelayTimeHandle);
    }

    public void AttackHandler()
    {
        if(Interrupted())
        {
            AttackReset();
            return;
        }

        if(AttackObject != null)
        {
            AttackObject.SetActive(true);
            GameObject attacker = GameObject.Instantiate(AttackObject, AttackObject.transform.position, Quaternion.identity);
            AttackObject.SetActive(false);
            attacker.GetComponent<IMoveOfSpawnObject>().SetMove();
        }
        
    }

    public bool Interrupted()
    {
        return playerController.IsHitting;
    }


}
