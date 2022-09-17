using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float AnimateTime = 0.5f;

    private void Update()
    {
        AnimateTime -= Time.deltaTime;
        if(AnimateTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
