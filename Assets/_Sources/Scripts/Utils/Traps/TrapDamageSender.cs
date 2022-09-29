using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrapDamageSender : MonoBehaviour, IDamageSender
{

    public List<GameObject> Receivers;

    public float DamagePerSeconds = 20;

    [SerializeField] private bool Detected;
    [SerializeField] private int ReceiverCount = 0;

    private void Start()
    {
        HandlePerOneSecond();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(Receivers.Contains(collider.gameObject))
        {
            Detected = true;
            ReceiverCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(Receivers.Contains(collider.gameObject))
        {
            ReceiverCount--;
            if(ReceiverCount == 0) Detected = false;
        }
    }

    private void HandlePerOneSecond()
    {
        Invoke("HandlePerOneSecond", 1f);
        if (ReceiverCount == 0) return;
        var damageReceivers = Receivers.Select(rv => rv.GetComponent<IDamageReceiver>());
        foreach (IDamageReceiver receiver in damageReceivers)
        {
            SendDamage(receiver);
        }
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
