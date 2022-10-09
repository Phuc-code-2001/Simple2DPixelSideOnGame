using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour, IItemCollector
{
    public PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Collect<T>(T item)
    {
        if(typeof(T) == typeof(Coin))
        {
            Coin coin = item as Coin;
            coin.gameObject.SetActive(false);
            playerController.playerInfoController.AddCoin(coin.UnitValue);
        }

        else if(typeof(T) == typeof(HPBottle))
        {
            HPBottle bottle = item as HPBottle;
            bottle.gameObject.SetActive(false);
            playerController.playerInfoController.HealHP(bottle.HealPoint);
        }

        else if(typeof(T) == typeof(Fruit))
        {
            Fruit fruit = item as Fruit;
            fruit.gameObject.SetActive(false);
            CollectedSpawner.Instance.SpawnCollected(fruit.transform.position);
            playerController.playerInfoController.HealMP(fruit.value);
        }
    }
}
