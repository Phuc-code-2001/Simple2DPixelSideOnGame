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
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if(playerController != null && !IsHandled)
        {
            IsHandled = true;
            if (DoneLevelSound != null)
            {
                SoundManager.Instance?.PlayOneShot(DoneLevelSound);
            }
            FlagOut();
            Invoke("DoneLevel", 1.5f);
            
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
