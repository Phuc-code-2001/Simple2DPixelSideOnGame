using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [Header("AudioController")]
    [Range(0, 1)]
    [SerializeField]
    private float baseVolume;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float value)
    {
        baseVolume = value;
        audioSource.volume = baseVolume;
    }

    public float GetVolume() => audioSource.volume;

    public void PlayOneShot(AudioClip clip, float subVolume = 1f)
    {
        audioSource.PlayOneShot(clip, baseVolume * subVolume);
    }

    public void DSXStart(AudioClip clip, float subVolume = 1f)
    {
        if (audioSource.clip == clip) return;
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = baseVolume * subVolume;
        audioSource.Play();
    }

    public void DSXStop(AudioClip clip)
    {
        if(clip == audioSource.clip) audioSource.Stop();
    }

}
