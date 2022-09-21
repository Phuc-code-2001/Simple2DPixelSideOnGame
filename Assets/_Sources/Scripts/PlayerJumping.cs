using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [Header("Controllers")]
    public PlayerController playerController;

    [Header("Properties")]
    public float PowerUnit = 10;
    public float JumpPower_01 = 35;
    public float JumpPower_02 = 40;
    public bool IsDoubleJump = false;

    [Header("Checker")]
    public bool CanDoubleJump = false;
    public bool CanJump = false;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void Jump()
    {
        ResetGravity();
        playerController.playerGroundedHandler.NonGroundedHandle();
        Vector2 force = new Vector2(0, PowerUnit * (IsDoubleJump ? JumpPower_02 : JumpPower_01));
        playerController.rb.AddForce(force, ForceMode2D.Force);
    }

    private void Update()
    {
        
        if (playerController.IsGrounded)
        {
            IsDoubleJump = false;
            CanDoubleJump = false;
            CanJump = true;
        }

        if (CanDoubleJump)
        {
            CanJump = true;
        }
        else if (playerController.IsFalling)
        {
            CanJump = false;
            playerController.inputController.JumpSignalActive = false;
            
        }
    }

    private void FixedUpdate()
    {

        if ((CanJump && playerController.inputController.JumpSignalActive))
        {
            if (CanDoubleJump)
            {
                CanDoubleJump = false;
                IsDoubleJump = true;
            }
            if (playerController.IsGrounded)
            {
                CanDoubleJump = true;
            }
            Jump();
            CanJump = false;
            playerController.inputController.JumpSignalActive = false;
        }

    }

    private void ResetGravity()
    {
        Vector2 temp_v = playerController.rb.velocity;
        playerController.rb.velocity = new Vector2(temp_v.x, 0);
    }
}
