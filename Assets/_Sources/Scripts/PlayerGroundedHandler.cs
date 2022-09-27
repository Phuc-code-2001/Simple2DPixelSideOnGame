using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerGroundedHandler : MonoBehaviour, IGroundedHandler
{

    [SerializeField] private PlayerController playerController;

    public GameObject GroundHandleEffectObject;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void GroundedHandle()
    {
        if(!playerController.IsGrounded && GroundHandleEffectObject != null)
        {
            Vector3 offset = Vector3.up * 0.65f;
            GameObject effect = GameObject.Instantiate(GroundHandleEffectObject, transform.position + offset, transform.rotation);
            Destroy(effect, 0.4f);
        }
        playerController.IsGrounded = true;
        playerController.IsJumping = false;
    }

    public void NonGroundedHandle()
    {
        playerController.IsGrounded = false;
    }
}
