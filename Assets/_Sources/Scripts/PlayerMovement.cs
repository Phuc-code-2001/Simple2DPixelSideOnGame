using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MaxSpeed = 12;
    public float PowerUp = 8f;
    public float PowerDown = 8f;

    public float MovingX = 0;

    private void Update()
    {
        float direction = InputController.Instance.Horizontal;
        Move(direction);

        if (direction != CurrentMoveDirect())
        {
            DecreaseSpeed();
        }

        CheckMaxSpeed();
    }

    public void Move(float direction)
    {
        PlayerController.Instance.rb.AddForce(new Vector2(PowerUp * direction, 0), ForceMode2D.Force);
    }

    private void DecreaseSpeed()
    {
        Vector2 velocity = PlayerController.Instance.rb.velocity;

        float temp_x = velocity.x + PowerDown * (-CurrentMoveDirect()) * Time.deltaTime;

        if (temp_x * velocity.x <= 0)
        {
            Stop();
        }
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
        MovingX = PlayerController.Instance.rb.velocity.x;
        if (MovingX > 0) return 1;
        if (MovingX < 0) return -1;
        return 0;
    }

    public void Stop()
    {
        PlayerController.Instance.rb.velocity = new Vector2(0, PlayerController.Instance.rb.velocity.y);
    }

}
