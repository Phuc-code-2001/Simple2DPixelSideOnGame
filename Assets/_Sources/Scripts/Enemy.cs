using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HealthPoint;
    public float Damage;


    public void ReceiveDamage(float dame)
    {
        HealthPoint -= dame;
    }

    public bool IsDeath() { return HealthPoint <= 0; }
}
