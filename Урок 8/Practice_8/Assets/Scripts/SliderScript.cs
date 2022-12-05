using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private AudioMixer menuAudioMixer;

    public void SetVolumeMaster(float sliderValue)
    {
        menuAudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeSound(float sliderValue)
    {
        menuAudioMixer.SetFloat("SoundsVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeMusic(float sliderValue)
    {
        menuAudioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

}
