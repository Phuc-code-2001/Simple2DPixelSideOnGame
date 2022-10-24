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
            StartCoroutine(UseEffect());
            UseSound();
        }
    }

    IEnumerator UseEffect()
    {
        playerController.IsHitting = true;
        SpawnEffect();
        yield return new WaitForSeconds(EffectTime);
        playerController.IsHitting = false;
    }

    private void UseSound()
    {
        playerController.playerAudioController.PlayHitSound();
    }

    private void SpawnEffect()
    {
        if (effectObject == null) return;
        GameObject effect = GameObject.Instantiate(effectObject, transform.position, transform.rotation);
        effect.SetActive(true);
    }

 }
