using System.Collections;
using UnityEngine;

public class KnifeAttackHandler : MonoBehaviour
{
    public int _maxAttacks = 3;
    public float _comboTime = 1;
    public float _damage = 0;
    public float _knifeDelay = 0.2f;

    private SpriteRenderer _knife;
    private Collider2D _knifeCollider;
    private int _attackCount;
    private float _currentComboTime;
    private MovementController _movementController;
    private GameObject _player;
    Animator _animator;
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _movementController = _player.GetComponent<MovementController>();
        _currentComboTime = _comboTime;
        _knife = GetComponent<SpriteRenderer>();
        _knife.enabled = false;
        _knifeCollider = GetComponent<Collider2D>();
        _knifeCollider.enabled = false;
        _animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        _currentComboTime -= Time.deltaTime;
        if (_currentComboTime <= 0) _attackCount = 0;
    }

    public void Attack()
    {
        if (_attackCount < _maxAttacks)
        {
            _audioManager.PlaySFX(_audioManager.Sword);
            StartCoroutine(Slice());
            // mandar evento de damage
            _currentComboTime = _comboTime;
            _attackCount++;
        }
        if (_attackCount >= _maxAttacks)
        {
            // mandar evento de stun
            Debug.Log("Combo!");
            _attackCount = 0;
        }
    }

    private IEnumerator Slice()
    {
        yield return new WaitForSeconds(_knifeDelay);
        _knife.enabled = true;
        _knifeCollider.enabled = true;
        _animator.SetBool("IsStriking", true);
        _movementController._canMove = false;
        yield return new WaitForSeconds(0.5f);
        _movementController._canMove = true;
        _animator.SetBool("IsStriking", false);
        _knifeCollider.enabled = false;
        _knife.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var _enemyHealth = other.gameObject.GetComponentInParent<EnemyHealthHandler>();
        var _lootBoxHealth = other.gameObject.GetComponent<LootBoxHealth>();
        if (_enemyHealth != null)
        {
            _enemyHealth.TakeDamage(_damage);
        }
        else if (_lootBoxHealth != null)
        {
            _lootBoxHealth.TakeDamage(_damage);
        }
    }
}