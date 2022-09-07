using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;

    public Rigidbody2D rb;
    public GameObject Knight;

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



    public void Jump(float power)
    {
        PlayerAnimationController ac = GetComponent<PlayerAnimationController>();
        ac.SetAnimationAction(PlayerAnimationController.AnimationActionTypes.Jump);
        rb.AddForce(new Vector2(0, power), ForceMode2D.Force);
    }

    private void Update()
    {
        if(InputController.Instance.JumpSignalActive > 0)
        {
            Jump(8);
        }
    }

    private void FixedUpdate()
    {
        IsGrounded = rb.velocity.y == 0;
        IsJumping = rb.velocity.y > 0;
        IsFalling = rb.velocity.y < 0;
    }

}
