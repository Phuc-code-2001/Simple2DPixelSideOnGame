using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestEffectSpawner : Spawner
{

    public static OpenChestEffectSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SpawnerObject == null) SpawnerObject = transform.GetChild(0).gameObject;
        SpawnerObject.SetActive(false);
    }

    public void SpawnEffect(Vector2 pos)
    {
        Spawn(1, pos, 0);
    }

}
