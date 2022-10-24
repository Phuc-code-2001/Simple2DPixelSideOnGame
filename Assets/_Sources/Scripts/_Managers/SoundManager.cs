using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField] private AudioSource source;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void SetVolume(float vol)
    {
        source.volume = vol;
    }

    private void Start()
    {
        AudioClip BGClip = source.clip;
        PlaySound(BGClip, true);
    }

    public float GetVolume()
    {
        return source.volume;
    }

    public void PlaySound(AudioClip clip, bool loop)
    {
        Stop();
        source.clip = clip;
        source.loop = loop;
        source.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        source.PlayOneShot(clip, source.volume);
    }


    public void Stop()
    {
        source.Stop();
    }
}
