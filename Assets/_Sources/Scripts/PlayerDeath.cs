using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDeathHandler
{
    public PlayerController playerController;

    public float DeathAnimateTime = 1.5f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void CheckDead()
    {
        if(playerController.HealthPoint <= 0)
        {
            playerController.IsDeath = true;
            Death();
        }
    }

    public void Death()
    {
        Invoke("Destruction", DeathAnimateTime);
    }

    public void Destruction()
    {
        Destroy(gameObject);
    }

}
