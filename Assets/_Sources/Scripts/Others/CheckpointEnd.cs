using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointEnd : MonoBehaviour
{
    Animator animator;

    bool IsHandled;

    [SerializeField] AudioClip DoneLevelSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsHandled) return;
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if(playerController != null)
        {
            if(DoneLevelSound != null)
            {
                SoundManager.Instance?.PlaySound(DoneLevelSound, false);
            }
            FlagOut();
            Invoke("DoneLevel", 1f);
            IsHandled = true;
        }
    }

    private void FlagOut()
    {
        animator.SetTrigger("Flagout");
    }

    private void DoneLevel()
    {
        GameManager.Instance?.EndLevel();
    }


}
