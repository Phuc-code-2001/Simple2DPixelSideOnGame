using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
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
            Invoke("Dead", DeathAnimateTime);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);

    }

}
