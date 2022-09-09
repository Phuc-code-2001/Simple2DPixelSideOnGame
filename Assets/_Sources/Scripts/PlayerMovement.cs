using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    
    public PlayerController playerController;

    public float MaxSpeed = 6f;
    public float PowerUp = 4f;
    public float PowerDown = 12f;

    public float MoveX = 0;

    public float LastMoveX = 0;

    public bool IsPowerUp = false;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        MoveX = InputController.Instance.Horizontal;
        IsPowerUp = InputController.Instance.RunSignalActive;
        LastMoveX = PlayerController.Instance.rb.velocity.x;
    }

    private void FixedUpdate()
    {

        if(MoveX != 0) Move(MoveX);
        if (MoveX != CurrentMoveDirect()) DecreaseSpeed();
        if (IsPowerUp) Accel();
        
        ResetSpeed();
        CheckMaxSpeed();
        PlayFacing();
    }

    private void ResetSpeed()
    {

        if(!IsPowerUp)
        {
            MaxSpeed = 6f;
            PowerUp = 4f;
        }

        float curr = PlayerController.Instance.rb.velocity.x;
        if(curr * LastMoveX < 0) Stop();
    }

    public void Move(float direction)
    {
        PlayerController.Instance.rb.AddForce(new Vector2(PowerUp * direction, 0), ForceMode2D.Force);
    }

    private void DecreaseSpeed()
    {
        Vector2 velocity = PlayerController.Instance.rb.velocity;
        float temp_x = velocity.x + PowerDown * (-CurrentMoveDirect()) * Time.deltaTime;
        velocity.x = temp_x;
        PlayerController.Instance.rb.velocity = velocity;
    }

    private void CheckMaxSpeed()
    {
        if (Mathf.Abs(PlayerController.Instance.rb.velocity.x) > MaxSpeed)
        {
            PlayerController.Instance.rb.velocity = new Vector2
            {
                x = MaxSpeed * CurrentMoveDirect(),
                y = PlayerController.Instance.rb.velocity.y
            };
        }
    }

    private float CurrentMoveDirect()
    {
        if (LastMoveX > 0) return 1;
        if (LastMoveX < 0) return -1;
        return 0;
    }

    public void Stop()
    {
        Vector2 temp_v = PlayerController.Instance.rb.velocity;
        PlayerController.Instance.rb.velocity = new Vector2(0, temp_v.y);
    }

    public void Accel()
    {
        PlayerController.Instance.rb.AddForce(new Vector2(PowerUp * CurrentMoveDirect(), 0), ForceMode2D.Force);
        MaxSpeed = 18;
        PowerUp = 12;
    }

    public void PlayFacing()
    {
        if(LastMoveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (LastMoveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
