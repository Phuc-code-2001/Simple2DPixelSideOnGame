using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordDamageSender : MonoBehaviour, IDamageSender, IMoveOfSpawnObject
{

    private Rigidbody2D rb;
    private Transform parent;
    [SerializeField] private float Speed = 15;
    [SerializeField] private float MaxDistance = 6;
    [SerializeField] private int numberOfSlashed = 0;
    [SerializeField] private float scaleNeftDameOnTarget = 40;

    public List<string> AttackToTags = new List<string>() { "Enemy", "Chest", "Boss" };
    private List<GameObject> CollapsedObjects = new List<GameObject>();

    [Header("Debug")]
    [SerializeField] private float CurrentDistance = 0;
    [SerializeField] private Vector2 startLocalAt;
    [SerializeField] private Vector2 startWorldAt;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        parent = transform.parent;
        startLocalAt = transform.localPosition;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        startWorldAt = transform.position;
        SetMove();
        transform.parent = null;
    }

    private void FixedUpdate()
    {
        CurrentDistance = Vector2.Distance(transform.position, startWorldAt);
        if (CurrentDistance > MaxDistance)
        {
            StopMove();
            Reset();
            gameObject.SetActive(false);
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
        rb.velocity = new Vector2(Speed * transform.lossyScale.x, 0);
    }

    private void StopMove()
    {
        rb.velocity = new Vector2(0, 0);
    }

    private void Reset()
    {
        transform.parent = parent;
        transform.localPosition = startLocalAt;
        transform.localScale = Vector3.one;
        CollapsedObjects.Clear();
        numberOfSlashed = 0;
    }
}
