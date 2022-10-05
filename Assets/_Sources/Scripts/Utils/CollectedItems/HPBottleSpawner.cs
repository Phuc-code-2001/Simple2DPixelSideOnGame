using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBottleSpawner : Spawner
{
    public static HPBottleSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SpawnerObject == null) SpawnerObject = transform.Find("HPBottle").gameObject;
        SpawnerObject.SetActive(false);
    }

}
