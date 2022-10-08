using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public float volume;

    private void Awake()
    {
        Instance = this;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }

    public void PlaySound(AudioSource source)
    {
        source.Play();
    }


}
