using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour
{

    [Header("Properties")]
    public float animationTime = 0.66f;

    private void Start()
    {
        Invoke("EffectDone", animationTime);
    }

    private void EffectDone()
    {
        Destroy(gameObject);
    }

}
