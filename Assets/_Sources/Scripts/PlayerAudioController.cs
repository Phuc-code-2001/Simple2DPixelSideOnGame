using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : AudioController
{

    [Header("AudioClips")]
    public AudioClip HitAudioClip;
    public AudioClip JumpAudioClip;
    public AudioClip MoveAudioClip;

    private void Awake()
    {
        if (FSXAudioSource == null) FSXAudioSource = GetComponent<AudioSource>();
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

    public void StartMoveSound()
    {
        DSXStart(MoveAudioClip);
    }

    public void StopMoveSound()
    {
        if(DSXAudioSouce.clip == MoveAudioClip)
        {
            DSXStop();
        }
    }
}
