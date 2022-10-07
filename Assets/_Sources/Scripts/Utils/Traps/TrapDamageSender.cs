using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrapDamageSender : MonoBehaviour, IDamageSender
{

    public List<GameObject> Receivers;

    public List<IDamageReceiver> CurrentReceivers = new List<IDamageReceiver>();

    public float DamagePerSeconds = 20;

    private void Start()
    {
        HandlePerOneSecond();
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

    private void HandlePerOneSecond()
    {
        Invoke("HandlePerOneSecond", 1f);
        var damageReceivers = Receivers.Select(rv => rv.GetComponent<IDamageReceiver>());
        foreach (IDamageReceiver receiver in CurrentReceivers)
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
