using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;

    [Header("Components")]
    public Rigidbody2D rb;
    public InputController inputController;
    public PlayerMovement playerMovement;
    public PlayerJumping playerJumping;
    public PlayerAnimationController playerAnimationController;
    public PlayerGroundedHandler playerGroundedHandler;
    public PlayerAttacker playerAttacker;
    public PlayerDamageReceiver playerDamageReceiver;
    public PlayerDeath playerDeath;
    public PlayerInfoController playerInfoController;

    [Header("Children Components")]
    public PlayerAudioController playerAudioController;

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
        playerInfoController = GetComponent<PlayerInfoController>();

        playerAudioController = GetComponentInChildren<PlayerAudioController>();
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
        IsFalling = rb.velocity.y < -0.25f && !IsGrounded;
        IsDeath = playerInfoController.HealthPoint <= 0;
    }

}
