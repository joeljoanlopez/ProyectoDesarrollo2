using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;

    public void Start()
    {
        _currentHealth = _maxHealth;
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
        Destroy(gameObject);
    }
}