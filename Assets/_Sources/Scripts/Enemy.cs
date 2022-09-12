using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HealthPoint = 1;
    public float Damage = 1;


    public void ReceiveDamage(float dame)
    {
        HealthPoint -= dame;
    }

    public bool IsDeath() { return HealthPoint <= 0; }

}
