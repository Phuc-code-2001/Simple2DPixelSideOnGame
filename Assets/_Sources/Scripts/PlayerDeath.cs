using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerDeath : MonoBehaviour, IDeathHandler
{
    public PlayerController playerController;

    public float DeathAnimateTime = 1.5f;
    private bool IsHandleDeath;

    private void Awake()
    {
        IsHandleDeath = false;
        playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        IsHandleDeath = false;
    }

    private void Update()
    {
        if(playerController.IsDeath && !IsHandleDeath)
        {
            Death();
            IsHandleDeath = true;
        }
    }

    public void Death()
    {
        Invoke("Destruction", DeathAnimateTime);
    }

    public void Destruction()
    {
        gameObject.SetActive(false);
        GameManager.Instance?.GameOver();
    }

}
