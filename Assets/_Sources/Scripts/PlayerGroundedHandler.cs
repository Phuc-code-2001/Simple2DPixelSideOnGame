using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedHandler : MonoBehaviour, IGroundedHandler
{

    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void GroundedHandle()
    {
        playerController.IsGrounded = true;
    }

    public void NonGroundedHandle()
    {
        playerController.IsGrounded = false;
    }
}
