using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    public class AnimationNameTypes
    {
        public static string Idle_01 = "idle_1";
        public static string Idle_02 = "idle_2";
        public static string Idle_Shield = "idle_3";
        public static string Walk = "walk";
        public static string Walk_Shield = "walk_shield";
        public static string Run = "run";
        public static string Run_Shield = "run_shield";
        public static string Attack_Sword = "sword_attack";
        public static string Attack_Shield = "shield_attack";
        public static string Jump = "jump";
        public static string Stun = "stun";
        public static string Hit = "hit";
        public static string Dead = "dead";
        public static string Buff_Damage = "buff_1";
        public static string Buff_Health = "buff_2";
        public static string Buff_Speed = "buff_3";
    }

    public enum AnimationActionTypes
    {
        Idle,
        Walk,
        Run,
        Attack_Sword,
        Attack_Shield,
        Jump,
        Stun,
        Dead,
        Buff_Damage,
        Buff_Health,
        Buff_Speed,
    }

    public PlayerController playerController;
    public GameObject Knight;
    public KnightControl playerKnightControl;
    public SkeletonAnimation playerKnightSeletonAnimation;

    [SerializeField]
    private AnimationActionTypes runtimeActionType = AnimationActionTypes.Idle;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        Knight = playerController.transform.Find("Knight").gameObject;
        playerKnightControl = Knight.GetComponent<KnightControl>();
        playerKnightSeletonAnimation = Knight.GetComponent<SkeletonAnimation>();
    }

    public void SetAnimationAction(AnimationActionTypes actionType)
    {
        string actionName = GetActionName(actionType);

        switch (actionType)
        {
            case AnimationActionTypes.Idle:
                if (!playerController.IsGrounded) { break; }
                if (playerKnightControl.idleAnimationName != actionName)
                {
                    playerKnightControl.idleAnimationName = actionName;
                    playerKnightControl.idle();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.idle();
                }
                break;

            case AnimationActionTypes.Walk:
                if (playerKnightControl.walkAnimationName != actionName)
                {
                    playerKnightControl.walkAnimationName = actionName;
                    playerKnightControl.walking();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.walking();
                }

                break;

            case AnimationActionTypes.Run:
                if (playerKnightControl.runAnimationName != actionName)
                {
                    playerKnightControl.runAnimationName = actionName;
                    playerKnightControl.running();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.running();
                }

                break;

            case AnimationActionTypes.Attack_Sword:
                if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.attack_1();
                }
                break;

            case AnimationActionTypes.Attack_Shield:
                if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.attack_2();
                }
                break;

            case AnimationActionTypes.Jump:
                if (playerKnightControl.jumpAnimationName != actionName)
                {
                    playerKnightControl.jumpAnimationName = actionName;
                    playerKnightControl.jump();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.jump();
                }
                break;

            case AnimationActionTypes.Stun:
                if (playerKnightControl.stunAnimationName != actionName)
                {
                    playerKnightControl.stunAnimationName = actionName;
                    playerKnightControl.stun();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.stun();
                }
                break;

            case AnimationActionTypes.Dead:
                if (playerKnightControl.deathAnimationName != actionName)
                {
                    playerKnightControl.deathAnimationName = actionName;
                    playerKnightControl.death();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.death();
                }
                break;

            case AnimationActionTypes.Buff_Damage:
                if (playerKnightControl.skillAnimationName_1 != actionName)
                {
                    playerKnightControl.skillAnimationName_1 = actionName;
                    playerKnightControl.skill_1();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.skill_1();
                }
                break;

            case AnimationActionTypes.Buff_Health:
                if (playerKnightControl.skillAnimationName_2 != actionName)
                {
                    playerKnightControl.skillAnimationName_2 = actionName;
                    playerKnightControl.skill_2();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.skill_2();
                }
                break;

            case AnimationActionTypes.Buff_Speed:
                if (playerKnightControl.skillAnimationName_3 != actionName)
                {
                    playerKnightControl.skillAnimationName_3 = actionName;
                    playerKnightControl.skill_3();
                }
                else if (actionType != runtimeActionType)
                {
                    runtimeActionType = actionType;
                    playerKnightControl.skill_3();
                }

                break;

        }
    
        
    }

    public string GetActionName(AnimationActionTypes actionType)
    {
        switch (actionType)
        {
            case AnimationActionTypes.Idle:
                return playerController.IsShieldActive ? AnimationNameTypes.Idle_Shield : AnimationNameTypes.Idle_02;

            case AnimationActionTypes.Walk:
                return playerController.IsShieldActive ? AnimationNameTypes.Walk_Shield : AnimationNameTypes.Walk;

            case AnimationActionTypes.Run:
                return playerController.IsShieldActive ? AnimationNameTypes.Run_Shield : AnimationNameTypes.Run;
            
            case AnimationActionTypes.Attack_Sword:
                return AnimationNameTypes.Attack_Sword;

            case AnimationActionTypes.Attack_Shield:
                return AnimationNameTypes.Attack_Shield;

            case AnimationActionTypes.Jump:
                return AnimationNameTypes.Jump;

            case AnimationActionTypes.Stun:
                return AnimationNameTypes.Stun;

            case AnimationActionTypes.Dead:
                return AnimationNameTypes.Dead;

            case AnimationActionTypes.Buff_Damage:
                return AnimationNameTypes.Buff_Damage;

            case AnimationActionTypes.Buff_Health:
                return AnimationNameTypes.Buff_Health;

            case AnimationActionTypes.Buff_Speed:
                return AnimationNameTypes.Buff_Speed;

        }

        return AnimationNameTypes.Idle_01;
    }

}
