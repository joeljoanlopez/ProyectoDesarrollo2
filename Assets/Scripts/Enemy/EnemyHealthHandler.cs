using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;
    public EnemyDrops _enemyDrop;

    private GameObject _drop;

    public void Start()
    {
        _currentHealth = _maxHealth;
        
        _drop = _enemyDrop.GetDrop();
    }

    public void Update()
    {
        if (_currentHealth <= 0 || Input.GetKeyDown(KeyCode.T))
            Die();
        if (Input.GetKeyDown(KeyCode.L))
            TakeDamage(10);
    }

    public void TakeDamage(float value)
    {
        // Animacion de damage
        _currentHealth -= value;
    }

    public void Die()
    {
        // Animacion de muerte
        _enemyDrop.DropSomething(_drop);
        Destroy(gameObject);
    }
}