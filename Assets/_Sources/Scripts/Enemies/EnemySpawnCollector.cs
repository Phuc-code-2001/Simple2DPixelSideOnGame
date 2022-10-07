using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCollector : MonoBehaviour
{
    public int MaxNumberOfCoins = 1;
    public float CoinDropRate = 0.5f;

    public int NumberOfHpBottle = 1;
    public float HpBottleDropRate = 0.5f;


    public void SpawnItems()
    {
        SpawnCoin();
        SpawnHpBottle();
    }

    private void SpawnCoin()
    {
        int count = 0;
        for(int i = 0; i < MaxNumberOfCoins; i++)
        {
            if (GetLucky(CoinDropRate)) count++;
        }
        if (count > 0) CoinSpawner.Instance?.SpawnCoin(count, transform.position, 1.5f);
    }
    
    private void SpawnHpBottle()
    {
        int count = 0;
        for(int i = 0; i < NumberOfHpBottle; i++)
        {
            if (GetLucky(HpBottleDropRate)) count++;
        }
        if (count > 0) HPBottleSpawner.Instance?.Spawn(count, transform.position, 1.5f);
    }


    public static bool GetLucky(float rate)
    {
        int luckyRange_Max = 50 + (int) ((100 * rate) / 2);
        int luckyRange_Min = 50 - (int) ((100 * rate) / 2);
        int randomNumber = Random.Range(0, 100);
        if(luckyRange_Min <= randomNumber && randomNumber <= luckyRange_Max)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
