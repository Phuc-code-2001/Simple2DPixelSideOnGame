using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Controllers")]
    public PlayerController playerController;

    [Header("Properties")]
    public float BaseMaxSpeed = 5;
    public float BasePowerUp = 3;
    [SerializeField] private float MaxSpeedWhenRun => BaseMaxSpeed * 2;
    [SerializeField] private float MaxPowerUpWhenRun => BasePowerUp * 4;
    public float CurrentMaxSpeed;
    public float CurrentPowerUp;

    public float PowerDown = 12f;
    public float MoveX = 0;
    public float LastMoveX = 0;

    [Header("Events")]
    public bool IsPowerUp = false;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        ResetAccelEffect();
    }

    private void ResetAccelEffect()
    {
        CurrentMaxSpeed = BaseMaxSpeed;
        CurrentPowerUp = BasePowerUp;
    }

    private void Update()
    {
        MoveX = InputController.Instance.Horizontal;
        IsPowerUp = InputController.Instance.RunSignalActive;
        LastMoveX = PlayerController.Instance.rb.velocity.x;
    }

    private void FixedUpdate()
    {

        if (IsPowerUp) Accel();
        if(MoveX != 0) Move(MoveX);
        if (MoveX != CurrentMoveDirect()) DecreaseSpeed();
        
        ResetSpeed();
        CheckMaxSpeed();
        PlayFacing();
    }

    private void ResetSpeed()
    {

        if(!IsPowerUp)
        {
            ResetAccelEffect();
        }

        float curr = PlayerController.Instance.rb.velocity.x;
        if(curr * LastMoveX < 0) Stop();
    }

    public void Move(float direction)
    {
        PlayerController.Instance.rb.AddForce(new Vector2(CurrentPowerUp * direction, 0), ForceMode2D.Force);
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
        if (Mathf.Abs(PlayerController.Instance.rb.velocity.x) > CurrentMaxSpeed)
        {
            PlayerController.Instance.rb.velocity = new Vector2
            {
                x = CurrentMaxSpeed * CurrentMoveDirect(),
                y = PlayerController.Instance.rb.velocity.y
            };
        }
    }

    public float CurrentMoveDirect()
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
        CurrentMaxSpeed = MaxSpeedWhenRun;
        CurrentPowerUp = MaxPowerUpWhenRun;
        // PlayerController.Instance.rb.AddForce(new Vector2(CurrentPowerUp * CurrentMoveDirect(), 0), ForceMode2D.Force);
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
