using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    public PlayerController playerController;


    [SerializeField] private float PowerUnit = 10;
    public float JumpPower_01 = 32;
    public float JumpPower_02 = 20;
    public bool IsDoubleJump = false;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Jump()
    {
        ResetGravity();
        Vector2 force = new Vector2(0, PowerUnit * (IsDoubleJump ? JumpPower_02 : JumpPower_01));
        playerController.rb.AddForce(force, ForceMode2D.Force);

        playerController.playerGroundedHandler.NonGroundedHandle();
    }

    private void Update()
    {
        if (playerController.IsGrounded)
        {
            IsDoubleJump = false;
        }
    }

    private void FixedUpdate()
    {
        if(InputController.Instance.JumpSignalActive && (playerController.IsGrounded || !IsDoubleJump))
        {
            if (!playerController.IsGrounded) IsDoubleJump = true;
            Jump();
            InputController.Instance.JumpSignalActive = false;
        }
    }

    private void ResetGravity()
    {
        Vector2 temp_v = playerController.rb.velocity;
        playerController.rb.velocity = new Vector2(temp_v.x, 0);
    }
}
