using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthBarHelper
{
    public float MaxHealthPoint = 1;
    public float HealthPoint = 1;
    public float Damage = 1;

    public bool CanFly = false;


    public void ReceiveDamage(float dame)
    {
        HealthPoint -= dame;
    }

    public bool IsDeath() { return HealthPoint <= 0; }

    public float GetMaxHealth()
    {
        return MaxHealthPoint;
    }

    public float GetCurrentHealth()
    {
        return HealthPoint;
    }
}
