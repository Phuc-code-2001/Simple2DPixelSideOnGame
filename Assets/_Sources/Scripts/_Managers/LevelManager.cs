using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Int32 killEnemies = 0;
    private Int32 colectedCoin = 0;
    private TimeSpan doneLevelTime;

    public bool isFinished = false;

    [SerializeField] private Text EnemyCountText;
    [SerializeField] private Text CoinCountText;
    [SerializeField] private Text TimeCountText;

    public void EnemyKilled()
    {
        killEnemies++;
    }

    public void CollectedCoin(float value)
    {
        colectedCoin += (int) value;
    }

    private void FixedUpdate()
    {
        if(!isFinished) doneLevelTime += TimeSpan.FromSeconds(Time.fixedDeltaTime);
    }

    public void Reset()
    {
        killEnemies = 0;
        colectedCoin = 0;
        doneLevelTime = TimeSpan.Zero;
        isFinished = false;
    }

    public void Finish()
    {
        isFinished = true;

        EnemyCountText.text = killEnemies.ToString();
        CoinCountText.text = colectedCoin.ToString();
        TimeCountText.text = $"{doneLevelTime.Minutes}m{doneLevelTime.Seconds}s";
    }
}
