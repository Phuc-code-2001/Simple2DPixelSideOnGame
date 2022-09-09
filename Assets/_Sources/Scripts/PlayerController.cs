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

    public PlayerMovement playerMovement;
    public PlayerJumping playerJumping;
    public PlayerAnimationController playerAnimationController;
    public PlayerGroundedHandler playerGroundedHandler;

    public GameObject Knight;

    public Rigidbody2D rb;

    public bool IsShieldActive = false;
    public bool IsGrounded;
    public bool IsJumping;
    public bool IsFalling;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        Knight = transform.Find("Knight")?.gameObject;
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerJumping = GetComponent<PlayerJumping>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
        playerGroundedHandler = GetComponent<PlayerGroundedHandler>();
    }

    private void FixedUpdate()
    {
        IsJumping = rb.velocity.y > 0;
        IsFalling = rb.velocity.y < 0;
    }

    

}
