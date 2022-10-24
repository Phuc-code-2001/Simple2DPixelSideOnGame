using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : AudioController
{

    [Header("AudioClips")]
    public AudioClip HitAudioClip;
    public AudioClip JumpAudioClip;
    public AudioClip SwordAttackClip;
    public AudioClip MoveAudioClip;

    private void Start()
    {
        
    }

    public void PlayHitSound()
    {
        if(HitAudioClip != null)
        {
            PlayOneShot(HitAudioClip);
        }
    }

    public void PlayJumpSound()
    {
        if(JumpAudioClip != null)
        {
            PlayOneShot(JumpAudioClip);
        }
    }

    public void PlaySwordAttackSound()
    {
        if(SwordAttackClip != null)
        {
            PlayOneShot(SwordAttackClip);
        }
    }

    public void StartMoveSound()
    {
        if(MoveAudioClip != null)
        {
            DSXStart(MoveAudioClip);
        }
    }

    public void StopMoveSound()
    {
        if(MoveAudioClip != null)
        {
            DSXStop(MoveAudioClip);
        }
    }
}
