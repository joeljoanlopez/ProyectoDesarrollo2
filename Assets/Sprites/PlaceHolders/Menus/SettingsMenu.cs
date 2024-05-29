using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMix;
    public void Setvolume(float volume)
    {
        audioMix.SetFloat("Volume", volume);
    }
}
