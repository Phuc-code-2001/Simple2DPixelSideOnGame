using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamageSender : MonoBehaviour, IDamageSender, IEnemyBulletMoving
{
    public EnemyBee Bee;
    public Rigidbody2D rb;
    public float speed = 5;

    public float MaxDistanseSpawn = 10;
    public Vector2 StartPosition;

    public GameObject TargetObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"));
    }

    private void Start()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        float gap = Vector2.Distance(transform.position, StartPosition);
        if(gap > MaxDistanseSpawn)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // Debug.Log($"Pem player...{collision.collider.name}");
            SendDamage(collision.transform.GetComponent<IDamageReceiver>());
        }

        Destroy(gameObject);
    }

    public float GetDamage()
    {
        if(Bee != null)
        {
            return Bee.BeeDamage;
        }
        return 0;
    }

    public void SendDamage(IDamageReceiver receiver)
    {
        receiver.ReceiveDamage(this);
    }

    public void SetMoveTo(GameObject target)
    {
        TargetObject = target;
        if (TargetObject == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = TargetObject.transform.position - transform.position;
        rb.velocity = dir.normalized * speed;
        float angle = Mathf.Asin(dir.normalized.x) / Mathf.PI * 180;
        
        if(dir.normalized.y > 0)
        {
            angle = 180 - angle;
        }
        transform.eulerAngles = Vector3.forward * angle;
    }
}
