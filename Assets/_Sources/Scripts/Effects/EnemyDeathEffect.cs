using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour
{

    private float TimeScale = 0.66f;
    private float timer;


    private void OnEnable()
    {
        timer = TimeScale;
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
