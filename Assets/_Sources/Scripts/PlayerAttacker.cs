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

    public float DelayTimeSendDamage = 0.7f;

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
        inputController.AttackSignalActive = false;
        playerController.swordDamageSender.Disable();
    }

    public void AttackHandler()
    {
        SwordDamageSender swordDamageSender =
            GameObject.Instantiate(playerController.swordDamageSender.gameObject, new Vector2(0, 0), Quaternion.identity, playerController.transform)
            .GetComponent<SwordDamageSender>();
        swordDamageSender.Active();
    }


}
