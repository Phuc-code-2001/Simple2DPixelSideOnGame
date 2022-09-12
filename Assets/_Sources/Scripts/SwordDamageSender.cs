using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordDamageSender : MonoBehaviour, IDamageSender
{

    public PlayerController playerController;
    public Rigidbody2D rb;
    public float Speed = 5;
    public float distance;

    public bool IsAffect = false;

    public List<string> AffectTags = new List<string>()
    {
        "Enemy"
    };

    public List<int> AffectedList = new List<int>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponentInParent<PlayerController>();
    }

    public void Disable()
    {
        IsAffect = false;
        rb.velocity = new Vector2 (0, 0);
    }

    public void Active()
    {
        IsAffect = true;
        rb.velocity = new Vector2(Speed * playerController.transform.localScale.normalized.x, 0);
        AffectedList.Clear();
    }

    private void Start()
    {
        IsAffect = false;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(IsAffect)
        {
            int Id = collider.GetInstanceID();
            if (AffectedList.Contains(Id)) return;
            if(AffectTags.Contains(collider.tag))
            {
                IDamageReceiver receiver = collider.GetComponent<IDamageReceiver>();
                if(receiver != null)
                {
                    SendDamage(receiver);
                }
            }
            AffectedList.Add(Id);
        }
    }

    public float GetDamage()
    {
        return playerController.Damage;
    }

    public void SendDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this);
    }

}
