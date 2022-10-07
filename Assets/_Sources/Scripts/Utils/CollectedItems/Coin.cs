using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float UnitValue = 1;

    public GameObject collector;

    private void OnEnable()
    {
        collector = null;
    }

    private void Update()
    {
        if (collector != null)
        {
            IItemCollector itemCollector = collector.GetComponent<IItemCollector>();
            if(itemCollector != null)
            {
                itemCollector.Collect<Coin>(this);
                collector = null;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collector = collision.gameObject;
    }

}
