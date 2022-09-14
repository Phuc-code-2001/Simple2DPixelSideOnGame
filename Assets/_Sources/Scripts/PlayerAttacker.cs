using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttacker
{

    public PlayerController playerController;
    public InputController inputController;

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
        inputController = InputController.Instance;
        CoolDownTimer = AttackCoolDown;
    }

    private void Update()
    {
        CoolDownTimer -= Time.deltaTime;
        if(inputController.AttackSignalActive && !playerController.IsAttacking)
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
        inputController.AttackSignalActive = false;
        playerController.IsAttacking = false;
    }

    public void AttackHandler()
    {
        if(AttackObject != null)
        {
            GameObject attacker = GameObject.Instantiate(AttackObject, AttackObject.transform.position, Quaternion.identity, transform);
            attacker.SetActive(true);
        }
        
    }


}
