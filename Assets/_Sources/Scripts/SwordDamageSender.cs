using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordDamageSender : MonoBehaviour, IDamageSender, IMoveOfSpawnObject
{

    public Rigidbody2D rb;
    public float Speed = 15;
    public float MaxDistance = 6;

    [SerializeField] private float CurrentDistance = 0;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private int numberOfSlashed = 0;
    [SerializeField] private float scaleNeftDameOnTarget = 40;

    public List<string> AttackToTags = new List<string>() { "Enemy", "Chest", "Boss" };

    private List<GameObject> CollapsedObjects = new List<GameObject>();

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
        if (CollapsedObjects.Contains(collider.gameObject) || !AttackToTags.Contains(collider.tag)) return;

        IDamageReceiver receiver = collider.GetComponent<IDamageReceiver>();
        if(receiver != null)
        {
            SendDamage(receiver);
            numberOfSlashed++;
        }

        CollapsedObjects.Add(collider.gameObject);
    }

    public float GetDamage()
    {
        return PlayerController.Instance.playerInfoController.Damage * Mathf.Pow((100f - scaleNeftDameOnTarget) / 100f, numberOfSlashed);
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
