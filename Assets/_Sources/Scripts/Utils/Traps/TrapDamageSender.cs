using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrapDamageSender : MonoBehaviour, IDamageSender
{

    public List<GameObject> Receivers;

    public List<IDamageReceiver> CurrentReceivers = new List<IDamageReceiver>();

    public float DamagePerSeconds = 400;
    public float SendDamageTimer = 0;

    private void Start()
    {
        if(Receivers.Count == 0 && PlayerController.Instance != null)
        {
            Receivers.Add(PlayerController.Instance.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(Receivers.Contains(collider.gameObject))
        {
            IDamageReceiver damageReceiver = collider.GetComponent<IDamageReceiver>();
            if(damageReceiver != null)
            {
                CurrentReceivers.Add(damageReceiver);
                damageReceiver.ReceiveDamage(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(Receivers.Contains(collider.gameObject))
        {
            IDamageReceiver damageReceiver = collider.GetComponent<IDamageReceiver>();
            if (damageReceiver != null)
            {
                CurrentReceivers.Remove(damageReceiver);
            }
        }
    }

    private void FixedUpdate()
    {
        HandlePerOneSecond();
        if(SendDamageTimer > 0) SendDamageTimer -= Time.fixedDeltaTime;
    }

    private void HandlePerOneSecond()
    {
        if (SendDamageTimer > 0) return; 
        var damageReceivers = Receivers.Select(rv => rv.GetComponent<IDamageReceiver>());
        foreach (IDamageReceiver receiver in CurrentReceivers)
        {
            SendDamage(receiver);
        }
        if (Receivers.Count > 0) SendDamageTimer = 1;
    }

    public void SendDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this);
    }

    public float GetDamage()
    {
        return DamagePerSeconds;
    }
}
