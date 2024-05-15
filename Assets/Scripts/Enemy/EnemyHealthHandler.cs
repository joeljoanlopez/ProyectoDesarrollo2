using TMPro;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;
    public EnemyDrops _enemyDrop;
    public GameObject popUpDamagePrefab;
    public TMP_Text popUpText;

    private GameObject _drop;

    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Start()
    {
        _currentHealth = _maxHealth;
        
        _drop = _enemyDrop.GetDrop();
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
        popUpText.text = value.ToString();
        Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity);
        _audioManager.PlaySFX(_audioManager.EnemyHit);

    }

    public void Die()
    {
        // Animacion de muerte
        _enemyDrop.DropSomething(_drop);
        Destroy(gameObject);
    }
}