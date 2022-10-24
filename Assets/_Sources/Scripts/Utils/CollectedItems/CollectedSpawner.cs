using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedSpawner : Spawner
{
    public static CollectedSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SpawnerObject == null) SpawnerObject = transform.Find("Collected").gameObject;
        SpawnerObject.SetActive(false);
    }

    public void SpawnCollected(Vector2 pos, float radius = 0)
    {
        Spawn(1, pos, radius, 0, 0);
    }


}
