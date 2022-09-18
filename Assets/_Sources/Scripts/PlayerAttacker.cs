using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttacker
{

    public PlayerController playerController;

    public float AttackAnimateTime = 1.2f;
    public float AttackCoolDown = 1.5f;
    public float CoolDownTimer;

    public float DelayTimeHandle = 0.6f;
    public GameObject AttackObject;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        AttackObject = transform.Find("SwordAttack").gameObject;
    }

    private void Start()
    {
        CoolDownTimer = AttackCoolDown;
    }

    private void Update()
    {
        CoolDownTimer -= Time.deltaTime;
        if(playerController.inputController.AttackSignalActive && !playerController.IsAttacking)
        {
            if(CoolDownTimer <= 0)
            {
                Attack();
                Invoke("AttackDone", AttackAnimateTime);
            }
            
        }

        if (CoolDownTimer <= 0) CoolDownTimer = 0;
    }

    public void Attack()
    {
        playerController.IsAttacking = true;
        CoolDownTimer = AttackCoolDown;
        Invoke("AttackHandler", DelayTimeHandle);
    }

    public void AttackDone()
    {
        playerController.inputController.AttackSignalActive = false;
        playerController.IsAttacking = false;
    }

    public void AttackHandler()
    {
        if(playerController.IsHitting)
        {
            AttackDone();
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


}
