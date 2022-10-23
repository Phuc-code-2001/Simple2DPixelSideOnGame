using Assets._Sources.Scripts.SaveAndLoadData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInfoController : MonoBehaviour
{
    public PlayerController playerController;

    [Header("Properties")]
    private float MaxHealthPoints = 2000;
    private float MaxManaPoints = 200;

    public float HealthPoint;
    public float ManaPoint;
    public float Damage = 100;

    public float HealthPointRate => HealthPoint / MaxHealthPoints;
    public float ManaPointRate => ManaPoint / MaxManaPoints;

    [Header("Coin/Money")]
    public float Coin = 0;

    public bool ReloadDisplay = true;

    [Header("Auto Running")]
    public float MpRecoveryTime = 5;
    public float MpRecoveryValue = 20;

    private void LoadProperties()
    {
        if(GameManager.Instance != null)
        {
            Coin = GameManager.Instance.SelectedRecord.Coin;
        }
        SetDefault();
    }

    public void SetDefault()
    {
        HealthPoint = MaxHealthPoints;
        ManaPoint = MaxManaPoints;
        Damage = 100;
    }

    public void Reset()
    {
        LoadProperties();
        ReloadDisplay = true;
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        LoadProperties();
        StartCoroutine(MpRecoveryHandler());
    }

    public void ReceiveDamage(float dame)
    {
        if(HealthPoint > dame) HealthPoint -= dame; else HealthPoint = 0;
        ReloadDisplay = true;
    }

    public void UseMP(float mp)
    {
        if(ManaPoint > mp) ManaPoint -= mp; else ManaPoint = 0;
        if(ManaPoint < 0) ManaPoint = 0;
        ReloadDisplay = true;
    }

    public void HealHP(float point)
    {
        HealthPoint += point;
        if (HealthPoint > MaxHealthPoints) HealthPoint = MaxHealthPoints;
        ReloadDisplay = true;
    }

    public void HealMP(float point)
    {
        ManaPoint += point;
        if (ManaPoint > MaxManaPoints) ManaPoint = MaxManaPoints;
        ReloadDisplay = true;
    }

    public void AddCoin(float numberOfUnit)
    {
        Coin += numberOfUnit;
        ReloadDisplay = true;
    }

    float lastTimeHandler;
    IEnumerator MpRecoveryHandler()
    {
        while(true)
        {
            if (ManaPoint + MpRecoveryValue < MaxManaPoints) ManaPoint += MpRecoveryValue;
            else ManaPoint = MaxManaPoints;
            ReloadDisplay = true;
            yield return new WaitForSeconds(MpRecoveryTime);
        }
    }

}
