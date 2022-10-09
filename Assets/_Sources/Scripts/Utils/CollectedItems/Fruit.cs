using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    /// <summary>
    /// Mp recovery for collector
    /// </summary>

    public float value = 10;

    public GameObject collector;

    private void Update()
    {
        if (collector != null)
        {
            IItemCollector itemCollector = collector.GetComponent<IItemCollector>();
            if (itemCollector != null)
            {
                itemCollector.Collect<Fruit>(this);
                collector = null;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collector = collision.gameObject;
    }

}
