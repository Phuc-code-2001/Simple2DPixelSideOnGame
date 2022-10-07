using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{

    public static CoinSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(SpawnerObject == null) SpawnerObject = transform.Find("Coin").gameObject;
        SpawnerObject.SetActive(false);
    }

    public void SpawnCoin(int quantity, Vector2 pos, float radius = 1)
    {
        Spawn(quantity, pos, radius);
    }
}
