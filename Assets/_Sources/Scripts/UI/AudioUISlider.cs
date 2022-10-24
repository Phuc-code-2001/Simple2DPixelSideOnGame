using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AudioType
{
    Music,
    FSX,
}

public class AudioUISlider : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Text OutputText;

    [SerializeField] AudioType Type;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (OutputText != null) OutputText.text = slider.value.ToString("0");
        
        if(Type == AudioType.Music)
        {
            SetMusicVolumeUI();
        }
        else if(Type == AudioType.FSX)
        {
            SetFSXVolumeUI();
        }

    }

    public void OnChangeSlideValue(float value)
    {
        if(OutputText != null)
        {
            OutputText.text = value.ToString("0");
        }

        if (Type == AudioType.Music)
        {
            SetMusicVolume();
        }
        else if (Type == AudioType.FSX)
        {
            SetFSXVolume();
        }
    }

    private void SetMusicVolumeUI()
    {
        SoundManager soundManager = SoundManager.Instance;
        if (soundManager != null)
        {
            slider.value = soundManager.GetVolume() * 100;
            OutputText.text = (soundManager.GetVolume() * 100).ToString("0");
        }
    }

    private void SetFSXVolumeUI()
    {
        PlayerController playerController = PlayerController.Instance;
        if(playerController != null)
        {
            slider.value = playerController.playerAudioController.GetVolume() * 100;
            OutputText.text = (playerController.playerAudioController.GetVolume() * 100).ToString("0");
        }
    }

    private void SetMusicVolume()
    {
        SoundManager soundManager = SoundManager.Instance;
        if (soundManager != null)
        {
            soundManager.SetVolume(slider.value / 100f);
        }
    }

    private void SetFSXVolume()
    {
        PlayerController playerController = PlayerController.Instance;
        if (playerController != null)
        {
            playerController.playerAudioController.SetVolume(slider.value / 100f);
        }
    }

}
