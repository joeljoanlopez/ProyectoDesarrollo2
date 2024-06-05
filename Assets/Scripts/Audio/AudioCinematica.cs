using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCinematica : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Intro;
    public AudioClip Latidos;
    public AudioClip Scream;

    private void Start()
    {
        musicSource.clip = Intro;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        SFXSource.PlayOneShot(clip, volume);
    }
}
