using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    public AudioClip sound;

    private AudioSource audioSource;
    public List<Button> buttons;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach(Button button in buttons)
        {
            button.onClick.AddListener(PlaySoundEffect);
        }
    }

    public void PlaySoundEffect()
    {
        audioSource.PlayOneShot(sound);
    }
}
