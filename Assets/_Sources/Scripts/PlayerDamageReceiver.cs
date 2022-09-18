using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : MonoBehaviour, IDamageReceiver
{
    [Header("Controllers")]
    public PlayerController playerController;

    [Header("Properties")]
    public float EffectTime = 0.6f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void ReceiveDamage(IDamageSender sender)
    {
        if(!playerController.IsHitting)
        {
            float dameReceive = sender.GetDamage();
            playerController.ReceiveDamage(dameReceive);
            UseEffect();
        }
    }

    public void UseEffect()
    {
        playerController.IsHitting = true;
        Invoke("EndEffect", EffectTime);
    }

    public void EndEffect()
    {
        playerController.IsHitting = false;
    }

    
}
