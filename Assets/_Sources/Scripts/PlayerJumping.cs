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
        }
    }

    private void FixedUpdate()
    {
        if(InputController.Instance.JumpSignalActive && (playerController.IsGrounded || !IsDoubleJump))
        {
            InputController.Instance.JumpSignalActive = false;
            if (!playerController.IsGrounded) IsDoubleJump = true;
            Jump();
        }
    }

    private void ResetGravity()
    {
        Vector2 temp_v = playerController.rb.velocity;
        playerController.rb.velocity = new Vector2(temp_v.x, 0);
    }
}
