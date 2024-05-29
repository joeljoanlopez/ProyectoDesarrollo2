using TMPro;
using UnityEngine;

public class LootBoxHealth : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;
    public LootBoxDrop _lootBoxDrop;
    public GameObject popUpDamagePrefab;
    public TMP_Text _popUpText;

    AudioManager _audioManager;

    private GameObject _drop;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Start()
    {
        _currentHealth = _maxHealth;
        _drop = _lootBoxDrop.GetDrop();
    }

    public void Update()
    {
        if (_currentHealth <= 0)
            Die();
    }

    public void TakeDamage(float value)
    {
        // Animacion de damage
        _currentHealth -= value;
    }

    public void Die()
    {
        // Animacion de muerte
        _lootBoxDrop.DropSomething(_drop);
        Destroy(gameObject);
        _audioManager.PlaySFX(_audioManager.BoxBreak);

    }
}