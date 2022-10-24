using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private float TimeScale = 0.3f;
    private float timer;


    private void OnEnable()
    {
        timer = TimeScale;
    }

    private void FixedUpdate()
    {
        if(timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
