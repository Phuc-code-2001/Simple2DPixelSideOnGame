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

    }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        HealthPoint = MaxHealthPoints;
        ManaPoint = MaxManaPoints;
    }

    private void Start()
    {
        if(GameManager.Instance?.IsContinueGame == true)
        {
            LoadProperties();
        }
        MpRecovery();
    }

    private void Update()
    {
        
    }

    public void ReceiveDamage(float dame)
    {
        HealthPoint -= dame;
        ReloadDisplay = true;
    }

    public void UseMP(float mp)
    {
        ManaPoint -= mp;
        if(ManaPoint < 0) ManaPoint = 0;
        ReloadDisplay = true;
    }

    public void Heal(float point)
    {
        HealthPoint += point;
        ReloadDisplay = true;
    }

    private void MpRecovery()
    {
        Invoke("MpRecovery", MpRecoveryTime);
        if(ManaPoint + MpRecoveryValue < MaxManaPoints) ManaPoint += MpRecoveryValue;
        else ManaPoint = MaxManaPoints;
        ReloadDisplay = true;
    }

}
