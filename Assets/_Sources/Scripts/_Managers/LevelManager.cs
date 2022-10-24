using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Int32 killEnemies = 0;
    private Int32 colectedCoin = 0;
    private float StartAt;

    [SerializeField] private Text EnemyCountText;
    [SerializeField] private Text CoinCountText;
    [SerializeField] private Text TimeCountText;

    public static LevelManager Instance;

    private void Awake()
    {
        Debug.Log("Start Level");
        Instance = this;
    }

    private void Start()
    {
        Reset();
    }

    public void EnemyKilled()
    {
        killEnemies++;
    }

    public void CollectedCoin(float value)
    {
        colectedCoin += (int) value;
    }

    private void Reset()
    {
        killEnemies = 0;
        colectedCoin = 0;
        StartAt = Time.time;
    }

    public void SetResult()
    {
        EnemyCountText.text = killEnemies.ToString();
        CoinCountText.text = colectedCoin.ToString();

        TimeSpan doneLevelTime = CalculateTime();
        TimeCountText.text = $"{doneLevelTime.Minutes}m{doneLevelTime.Seconds}s";
    }

    private TimeSpan CalculateTime()
    {
        TimeSpan deltaTime = TimeSpan.FromSeconds(Time.time - StartAt);
        return deltaTime;
    }
}
