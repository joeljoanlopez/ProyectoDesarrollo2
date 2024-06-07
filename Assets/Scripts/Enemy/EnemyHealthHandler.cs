using TMPro;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;
    public EnemyDrops _enemyDrop;
    public GameObject popUpDamagePrefab;
    public TMP_Text popUpText;
    public bool _dropsSomething = false;

    private GameObject _drop;
    private AudioManager _audioManager;
    private Animator _animator;
    private bool _isDying = false;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _animator = GetComponent<Animator>();
    }

    public void Start()
    {
        _currentHealth = _maxHealth;
        _drop = _enemyDrop.GetDrop();
    }

    public void Update()
    {
        if (_currentHealth <= 0 && !_isDying)
            Die();
    }

    public void TakeDamage(float value)
    {
        // Animacion de damage
        _currentHealth -= value;
        popUpText.text = value.ToString();
        Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity);
        _audioManager.PlaySFX(_audioManager.EnemyHit);
    }

    public void Die()
    {
        _isDying = true;
        // Trigger the death animation
        _animator.SetTrigger("Die");

        // Play any death-related audio
        _audioManager.ChangeMusic(_audioManager.DarkAmbienceB);

        // Drop items
        if (_dropsSomething)
        {
            _enemyDrop.DropSomething(_drop);
        }
    }

    public void OnDeathAnimationComplete()
    {
        Destroy(gameObject);
    }
}