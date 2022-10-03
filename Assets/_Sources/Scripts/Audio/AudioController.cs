using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [Header("AudioController")]
    public static float volume = 1;
    public AudioSource FSXAudioSource;

    public AudioSource DSXAudioSouce;
    public AudioClip DSXPlayingClip;

    public void PlayOneShot(AudioClip clip)
    {
        FSXAudioSource.PlayOneShot(clip);
    }

    public void DSXStart(AudioClip clip)
    {
        if (DSXPlayingClip == clip) return;
        DSXPlayingClip = clip;
        DSXAudioSouce.clip = clip;
        DSXAudioSouce.loop = true;
        DSXAudioSouce.volume = volume;
        DSXAudioSouce.Play();
    }

    public void DSXStop()
    {
        DSXAudioSouce.Stop();
        DSXPlayingClip = null;
    }

}
