using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Controllers")]
    public PlayerController playerController;

    [Header("Properties")]
    public float BaseSpeed = 5;
    [SerializeField] private float SpeedWhenRun => BaseSpeed * 2;
    public float CurrentSpeed;

    public float UseMpInSeconds = 5;

    [Header("Signals")]
    public float MoveX = 0;
    public float LastMoveX = 0;

    [Header("Events")]
    public bool IsPowerUp;
    public bool IsGoDown;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        MoveX = playerController.inputController.Horizontal;
        IsPowerUp = playerController.inputController.RunSignalActive && playerController.playerInfoController.ManaPoint > 0;
        IsGoDown = playerController.inputController.Vertical < 0;

        LastMoveX = playerController.rb.velocity.x;

        Move();
        PlayFacing();
    }

    private void FixedUpdate()
    {
        if (IsPowerUp)
        {
            CurrentSpeed = SpeedWhenRun;
            if(LastMoveX != 0) playerController.playerInfoController.UseMP(UseMpInSeconds * Time.fixedDeltaTime);
        }
        else
        {
            CurrentSpeed = BaseSpeed;
        }

        if (IsGoDown) GoDown();
    }

    public void Move()
    {
        playerController.rb.velocity = new Vector2(CurrentSpeed * MoveX, playerController.rb.velocity.y);
    }

    public void GoDown()
    {
        GroundChecker checker = playerController.transform.Find("GroundChecker").GetComponent<GroundChecker>();
        if(checker.OnGround != null)
        {
            Platformer platformer = checker.OnGround.GetComponent<Platformer>();
            if(platformer != null)
            {
                platformer.ChangeLayer(platformer.SelfLayer);
            }
        }
    }

    public float LastMoveDirect()
    {
        if (LastMoveX > 0) return 1;
        if (LastMoveX < 0) return -1;
        return 0;
    }

    public void PlayFacing()
    {
        if(playerController.IsMoveRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (playerController.IsMoveLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
