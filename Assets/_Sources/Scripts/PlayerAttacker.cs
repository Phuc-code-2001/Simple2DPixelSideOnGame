using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour, IAttacker
{

    public PlayerController playerController;
    public InputController inputController;

    public float AttackAnimateTime = 1.4f;
    public float AttackCoolDown = 2f;
    public float CoolDownTimer;

    public float DelayTimeSendDamage = 0.5f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        inputController = InputController.Instance;
        CoolDownTimer = AttackCoolDown;
    }

    private void FixedUpdate()
    {
        CoolDownTimer -= Time.fixedDeltaTime;
        if(inputController.AttackSignalActive)
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
        CoolDownTimer = AttackCoolDown;
        Invoke("AttackHandler", DelayTimeSendDamage);
           
    }

    public void AttackDone()
    {
        
        DisableAttack();
    }

    public void AttackHandler()
    {
        playerController.swordDamageSender.Active();
    }

    public void DisableAttack()
    {
        inputController.AttackSignalActive = false;
        playerController.swordDamageSender.Disable();
    }

}
