using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float _health = 100f;
    public float _stunTime = 0.5f;
    public float timer = 0f;
    public bool gotHit;
    public bool _isDead;
    AudioManager _audioManager;
    public float _deathTimer;

    private MovementController _movementController;
    private WeaponHolderController _weaponHolderController;
    private Animator _animator;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start() {
        _movementController = GetComponent<MovementController>();
        _weaponHolderController = GetComponent<WeaponHolderController>();
        _animator = GetComponent<Animator>();

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
            _isDead = true;
        }
        if (gotHit)
        {
            timer = timer + Time.deltaTime;
        }
        if (timer >= _stunTime)
        {
            gotHit = false;
            timer = 0f;
            _animator.SetBool("Got Hit", false);
        }
        if (_health <= 0 && gotHit == false)
        {
            _isDead = true;
        }
        if (_isDead)
        {
            _animator.SetBool("IsDead", true);
            _deathTimer += Time.deltaTime;
        }
        if(_deathTimer >= 2.0f)
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
        gotHit = true;
        _animator.SetBool("Got Hit", true);
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
