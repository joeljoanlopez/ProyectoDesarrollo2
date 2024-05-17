using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]

    public AudioClip DarkiAmbienceA;
    public AudioClip DarkAmbienceB;
    public AudioClip CombatAlways;
    public AudioClip CombatBattle;
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

    private void Start()
    {
        musicSource.clip = DarkiAmbienceA;
        musicSource.Play();
    }
    
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
