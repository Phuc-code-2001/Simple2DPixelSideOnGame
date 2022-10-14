using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, ISpawnCollector
{

    public enum ChestType
    {
        Gold,
        Silver,
        Wooden,
    }

    public ChestType Type;
    public int MaxNumberOfCoins => 20 - (5 * (int) Type);
    public float CoinDropRate = 0.8f;

    public void SpawnItems()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        int count = 0;
        for (int i = 0; i < MaxNumberOfCoins; i++)
        {
            if (GetLucky(CoinDropRate)) count++;
        }
        if (count > 0) CoinSpawner.Instance?.SpawnCoin(count, transform.position, 1.5f);
    }

    public bool GetLucky(float rate)
    {
        int luckyRange_Max = 50 + (int)((100 * rate) / 2);
        int luckyRange_Min = 50 - (int)((100 * rate) / 2);
        int randomNumber = Random.Range(0, 100);
        if (luckyRange_Min <= randomNumber && randomNumber <= luckyRange_Max)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
