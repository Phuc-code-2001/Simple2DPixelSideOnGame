using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpossum : MonoBehaviour
{
    public Enemy BaseEnemy;

    public float OpposumHeathPoint = 200;
    public float OpposumDamage = 10;

    private void Awake()
    {
        BaseEnemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        if(BaseEnemy != null)
        {
            BaseEnemy.HealthPoint = OpposumHeathPoint;
            BaseEnemy.Damage = OpposumDamage;
        }
    }

}
