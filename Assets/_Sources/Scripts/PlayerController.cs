using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerJumping))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimationController))]
[RequireComponent(typeof(PlayerGroundedHandler))]
public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;
    
    [Header("Components")]
    public PlayerMovement playerMovement;
    public PlayerJumping playerJumping;
    public PlayerAnimationController playerAnimationController;
    public PlayerGroundedHandler playerGroundedHandler;
    public PlayerAttacker playerAttacker;
    public PlayerDamageReceiver playerDamageReceiver;
    public Rigidbody2D rb;

    [Header("Children")]
    public GameObject Knight;

    [Header("Object Status")]
    public bool IsShieldActive = true;
    public bool IsGrounded;
    public bool IsJumping;
    public bool IsFalling;
    public bool IsAttacking;
    public bool IsHitting;

    [Header("Properties")]
    public float HealthPoint = 1000;
    public float Damage = 100;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        playerJumping = GetComponent<PlayerJumping>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        playerGroundedHandler = GetComponent<PlayerGroundedHandler>();
        playerAttacker = GetComponent<PlayerAttacker>();
        playerDamageReceiver = GetComponent<PlayerDamageReceiver>();
    }

    private void Start()
    {
        Knight = transform.Find("Knight")?.gameObject;
    }

    private void Update()
    {
        IsJumping = rb.velocity.y > 0;
        IsFalling = rb.velocity.y < 0;
    }
}
