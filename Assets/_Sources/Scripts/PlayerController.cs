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
    public InputController inputController;
    public PlayerMovement playerMovement;
    public PlayerJumping playerJumping;
    public PlayerAnimationController playerAnimationController;
    public PlayerGroundedHandler playerGroundedHandler;
    public PlayerAttacker playerAttacker;
    public PlayerDamageReceiver playerDamageReceiver;
    public PlayerDeath playerDeath;
    public Rigidbody2D rb;

    [Header("Children")]
    public GameObject Knight;

    [Header("Object Status")]
    public bool IsShieldActive = true;
    public bool IsMoveLeft;
    public bool IsMoveRight;
    public bool IsRunning;
    public bool IsGrounded;
    public bool IsJumping;
    public bool IsFalling;
    public bool IsAttacking;
    public bool IsHitting;
    public bool IsDeath;

    [Header("Properties")]
    public float HealthPoint = 1000;
    public float Mana = 200;
    public float Damage = 50;

    private void Awake()
    {
        Instance = this;
        inputController = GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        playerJumping = GetComponent<PlayerJumping>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        playerGroundedHandler = GetComponent<PlayerGroundedHandler>();
        playerAttacker = GetComponent<PlayerAttacker>();
        playerDamageReceiver = GetComponent<PlayerDamageReceiver>();
        playerDeath = GetComponent<PlayerDeath>();
    }

    private void Start()
    {
        Knight = transform.Find("Knight")?.gameObject;
    }

    private void Update()
    {
        IsMoveLeft = inputController.Horizontal < 0;
        IsMoveRight = inputController.Horizontal > 0;
        IsRunning = inputController.RunSignalActive;
        IsJumping = rb.velocity.y > 0;
        IsFalling = rb.velocity.y < -0.25f;
    }

    public void ReceiveDamage(float dameReceive)
    {
        HealthPoint -= dameReceive;
        playerDeath.CheckDead();
    }

    public void UseMana(float mana)
    {
        Mana -= mana;
    }

}
