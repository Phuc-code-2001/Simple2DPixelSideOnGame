using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerDeath : MonoBehaviour, IDeathHandler
{
    public PlayerController playerController;

    public float DeathAnimateTime = 1.5f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(playerController.IsDeath)
        {
            Death();
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
