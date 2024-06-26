using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]

    public AudioClip Intro;
    public AudioClip Exterior;
    public AudioClip DarkAmbienceA;
    public AudioClip DarkAmbienceB;
    public AudioClip Combat;
    public AudioClip CombatHidden;
    public AudioClip MainTheme;
    public AudioClip PianoA;
    public AudioClip ScaryEffect;
    public AudioClip GunShot;
    public AudioClip Recharge;
    public AudioClip ShellHittingDown;
    public AudioClip BoxBreak;
    public AudioClip OpenCloseDoor;
    public AudioClip EnemyHit;
    public AudioClip PlayerTakeDamage;
    public AudioClip Huh1;
    public AudioClip Huh2;
    public AudioClip Huh3;
    public AudioClip Huh4;
    public AudioClip Huh5;
    public AudioClip Huh6;
    public AudioClip Enemigo1;
    public AudioClip Enemigo2;
    public AudioClip Enemigo3;
    public AudioClip Step;
    public AudioClip Sword;

    private void Start()
    {
        musicSource.clip = DarkAmbienceB;
        musicSource.Play();
    }
    
    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        SFXSource.PlayOneShot(clip,volume);
    }
    public void ChangeMusic(AudioClip newClip)
    {
        if (musicSource.clip != newClip)
        {
            musicSource.Stop();
            musicSource.clip = newClip;
            musicSource.Play();
        }
    }

}
