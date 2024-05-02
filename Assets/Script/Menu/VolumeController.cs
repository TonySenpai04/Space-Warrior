using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public List<AudioSource> musicAudios;
    public List<AudioSource> sfxAudios;
    public Slider musicSlider;
    public Slider sfxSlider;
    private void Start()
    {
        foreach (AudioSource source in sfxAudios)
        {
            source.volume=sfxSlider.value;
        }

        foreach (AudioSource source in musicAudios)
        {
            source.volume = musicSlider.value;
        }
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnFSXVolumeChanged);
    }
    void OnMusicVolumeChanged(float volume)
    {
        foreach (AudioSource source in musicAudios) { source.volume = volume; }
        
    }
    void OnFSXVolumeChanged(float volume)
    {
        foreach (AudioSource source in sfxAudios) { source.volume = volume; }

    }
}
