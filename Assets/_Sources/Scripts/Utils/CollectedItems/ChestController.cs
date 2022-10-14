using Assets._Sources.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IDamageReceiver
{
    Animator animator;
    bool isOpened;


    private void OnEnable()
    {
        isOpened = false;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        OpenChestEffectSpawner.Instance.SpawnEffect(transform.position);
        animator.SetTrigger("Open");
        Invoke("SpawnItems", 0.5f);
        isOpened = true;
    }

    private void SpawnItems()
    {
        Chest chest = GetComponentInChildren<Chest>();
        chest.SpawnItems();
    }

    public void ReceiveDamage(IDamageSender sender)
    {
        if (isOpened) return;
        if(sender is SwordDamageSender)
        {
            Open();
        }
    }
}
