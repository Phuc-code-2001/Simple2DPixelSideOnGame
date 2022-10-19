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
    public float Damage = 50;

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
        HealthPoint = GameManager.Instance.SelectedRecord.Player.HeathPoint;
        ManaPoint = GameManager.Instance.SelectedRecord.Player.ManaPoint;
        Coin = GameManager.Instance.SelectedRecord.Player.Coin;
    }

    public void SetProperties()
    {
        if (GameManager.Instance.SelectedRecord.Player == null) GameManager.Instance.SelectedRecord.Player = new Player();
        GameManager.Instance.UpdateRecord();
    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        HealthPoint = MaxHealthPoints;
        ManaPoint = MaxManaPoints;
    }

    public void Reset()
    {
        HealthPoint = MaxHealthPoints;
        ManaPoint = MaxManaPoints;
        ReloadDisplay = true;
    }

    private void Start()
    {
        if(GameManager.Instance?.StartMode == GameManager.GameStartMode.ContinueGame)
        {
            LoadProperties();
        }
        else
        {
            if(GameManager.Instance != null) SetProperties();
        }

        Invoke("MpRecoveryHandler", MpRecoveryTime);
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

    private void MpRecoveryHandler()
    {
        Invoke("MpRecoveryHandler", MpRecoveryTime);
        if(ManaPoint + MpRecoveryValue < MaxManaPoints) ManaPoint += MpRecoveryValue;
        else ManaPoint = MaxManaPoints;
        ReloadDisplay = true;
    }

}
