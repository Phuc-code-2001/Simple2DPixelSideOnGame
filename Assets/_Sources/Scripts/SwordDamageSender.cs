using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordDamageSender : MonoBehaviour, IDamageSender, IMoveOfSpawnObject
{

    public Rigidbody2D rb;
    public float Speed = 15;
    public float MaxDistance = 5;

    [SerializeField] private float CurrentDistance = 0;
    [SerializeField] private Vector2 startPosition;

    public List<string> AffectTags = new List<string>()
    {
        "Enemy"
    };

    public List<GameObject> AffectedList = new List<GameObject>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startPosition = transform.position;
        transform.localScale = PlayerController.Instance.transform.localScale;
    }

    private void FixedUpdate()
    {
        CurrentDistance = Vector2.Distance(transform.position, startPosition);
        if (CurrentDistance > MaxDistance)
        {
            StopMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (AffectedList.Contains(collider.gameObject)) return;
        if (!AffectTags.Contains(collider.tag)) return;
        
        IDamageReceiver receiver = collider.GetComponent<IDamageReceiver>();
        if(receiver != null)
        {
            SendDamage(receiver);
        }
        
        AffectedList.Add(collider.gameObject);
    }

    public float GetDamage()
    {
        return PlayerController.Instance.Damage;
    }

    public void SendDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this);
    }

    public void SetMove()
    {
        rb.velocity = new Vector2(Speed * PlayerController.Instance.transform.localScale.x, 0);
    }

    private void StopMove()
    {
        rb.velocity = new Vector2(0, 0);
        Destroy(gameObject);
    }
}
