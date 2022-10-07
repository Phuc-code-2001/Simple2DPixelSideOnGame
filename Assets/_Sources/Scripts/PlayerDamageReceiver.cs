using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerDamageReceiver : MonoBehaviour, IDamageReceiver
{
    [Header("Controllers")]
    public PlayerController playerController;

    [Header("Properties")]
    public float EffectTime = 0.6f;

    public GameObject effectObject;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void ReceiveDamage(IDamageSender sender)
    {
        if(!playerController.IsHitting)
        {
            float dameReceive = sender.GetDamage();
            playerController.playerInfoController.ReceiveDamage(dameReceive);
            UseEffect();
            UseSound();
        }
    }

    public void UseEffect()
    {
        playerController.IsHitting = true;
        Invoke("EndEffect", EffectTime);

        if (effectObject != null) SpawnEffect();
    }

    public void EndEffect()
    {
        playerController.IsHitting = false;
    }

    private void SpawnEffect()
    {
        GameObject effect = GameObject.Instantiate(effectObject, transform.position, transform.rotation);
        effect.SetActive(true);
    }

    private void UseSound()
    {
        playerController.playerAudioController.PlayHitSound();
    }
 }
