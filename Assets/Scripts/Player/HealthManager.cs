using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float _health = 100f;
    public float _stunTime = 0.5f;
    AudioManager _audioManager;

    private MovementController _movementController;
    private WeaponHolderController _weaponHolderController;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start() {
        _movementController = GetComponent<MovementController>();
        _weaponHolderController = GetComponent<WeaponHolderController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RemoveHealth(20);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddHealth(20);
        }
        if (_health <= 0)
        {
            RestartScene();
        }
    }

    public void AddHealth(int value)
    {
        _health += value;
    }

    public void RemoveHealth(float value)
    {
        _health -= value;
        _audioManager.PlaySFX(_audioManager.PlayerTakeDamage);
        // Animacion
        StartCoroutine(GetHit());
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator GetHit()
    {
        _movementController._canMove = false;
        _weaponHolderController.gameObject.SetActive(false);
        yield return new WaitForSeconds(_stunTime);
        _movementController._canMove = true;
        _weaponHolderController.gameObject.SetActive(true);
    }
}
