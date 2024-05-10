using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]

    public AudioClip Background;
    public AudioClip DarkAmbienceB;
    public AudioClip CombatAlways;
    public AudioClip CombatBattle;
    public AudioClip CombatHidden;
    public AudioClip MainTheme;
    public AudioClip PianoA;
    public AudioClip ScaryEffect;


    private void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }
    
}
