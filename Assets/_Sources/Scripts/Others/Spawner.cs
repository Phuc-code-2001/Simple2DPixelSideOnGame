using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{

    public GameObject SpawnerObject;
    protected List<GameObject> readyObjects = new List<GameObject>();

    private List<GameObject> CreateClone(int number)
    {
        List<GameObject> result = new List<GameObject>();
        if (SpawnerObject == null) return result;
        for (int i = 0; i < number; i++)
        {
            GameObject clone = GameObject.Instantiate(SpawnerObject, transform);
            result.Add(clone);
        }

        return result;
    }

    public void Spawn(int quantity, Vector2 pos, float radius = 1)
    {
        List<GameObject> items = new List<GameObject>();
        foreach (GameObject item in readyObjects)
        {
            if (!item.activeInHierarchy)
            {
                pos.x = pos.x + Random.Range(-radius, radius);
                item.transform.position = pos;
                items.Add(item);
                if (items.Count == quantity) break;
            }
        }

        if (items.Count < quantity)
        {
            var items_new = CreateClone(quantity - items.Count);
            readyObjects.AddRange(items_new);
            foreach (GameObject item in items_new)
            {
                pos.x = pos.x + Random.Range(-radius, radius);
                item.transform.position = pos;
                items.Add(item);
            }
        }

        foreach (GameObject item in items)
        {
            item.SetActive(true);
        }
    }

}
