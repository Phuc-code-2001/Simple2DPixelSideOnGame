using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpossum : Enemy, IEnemy
{

    private void Awake()
    {
        HealthPoint = 100;
        Damage = 20;
    }

    public Enemy GetEnemyObject()
    {
        return this;
    }
}
