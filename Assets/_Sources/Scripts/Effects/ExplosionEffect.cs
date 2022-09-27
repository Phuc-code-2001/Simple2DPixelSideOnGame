using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : Effect
{
    [Header("Properties")]
    public float TimeScale = 0.66f;

    private void Start()
    {
        EffectTimeScale = TimeScale;
        Invoke("Destruction", EffectTimeScale);
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }
}
