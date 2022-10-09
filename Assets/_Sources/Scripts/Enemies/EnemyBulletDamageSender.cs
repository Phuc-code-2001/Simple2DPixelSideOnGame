using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamageSender : MonoBehaviour, IDamageSender, IEnemyBulletMoving
{
    public Rigidbody2D rb;
    public float speed = 5;
    public float Damage = 0;

    public float MaxDistanseSpawn = 10;
    public Vector2 StartPosition;

    public GameObject TargetObject;
    public Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"));
    }

    private void Start()
    {
        StartPosition = transform.position;
        rb.velocity = velocity;
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
        IDamageReceiver damageReceiver = collision.collider.GetComponent<IDamageReceiver>();
        if (damageReceiver != null) SendDamage(damageReceiver);
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return Damage;
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
        velocity = dir.normalized * speed;
        float angle = Mathf.Asin(dir.normalized.x) / Mathf.PI * 180;
        if (dir.normalized.y > 0)
        {
            angle = 180 - angle;
        }
        transform.eulerAngles = Vector3.forward * angle;
    }
}
