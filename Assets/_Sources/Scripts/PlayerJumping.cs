using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerJumping : MonoBehaviour
{
    [Header("Controllers")]
    public PlayerController playerController;

    [Header("Properties")]
    public float PowerUnit = 1;
    public float JumpPower_01 = 8;
    public float JumpPower_02 = 8;
    public bool IsDoubleJump = false;

    public float DoubleJumpManaUse = 20;

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
        playerController.IsJumping = true;
        Vector2 force = new Vector2(0, PowerUnit * (IsDoubleJump ? JumpPower_02 : JumpPower_01));
        playerController.rb.AddForce(force, ForceMode2D.Impulse);
        UseEffect();
        UseSound();
    }

    public void UseEffect()
    {
        
    }

    private void UseSound()
    {
        if(playerController.playerAudioController != null) playerController.playerAudioController.PlayJumpSound();
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
                playerController.playerInfoController.UseMP(DoubleJumpManaUse);
            }
            if (playerController.IsGrounded)
            {
                CanDoubleJump = true && playerController.playerInfoController.ManaPoint >= DoubleJumpManaUse;
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
