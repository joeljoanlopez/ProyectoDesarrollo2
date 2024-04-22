using System.Collections;
using UnityEngine;

public class KnifeAttackHandler : MonoBehaviour
{
    public int _maxAttacks = 3;
    public float _comboTime = 1;
    public float _damage = 0;

    private SpriteRenderer _knife;
    private Collider2D _knifeCollider;
    private int _attackCount;
    private float _currentComboTime;

    private void Start(){
        _currentComboTime = _comboTime;
        _knife = GetComponent<SpriteRenderer>();
        _knife.enabled = false;
        _knifeCollider = GetComponent<Collider2D>();
        _knifeCollider.enabled = false;
    }

    private void Update(){
        _currentComboTime -= Time.deltaTime;
        if (_currentComboTime <= 0) _attackCount = 0;
    }

    public void Attack()
    {
        if (_attackCount < _maxAttacks)
        {
            StartCoroutine(Slice());
            // mandar evento de damage
            _currentComboTime = _comboTime;
            _attackCount++;
        }
        if (_attackCount >= _maxAttacks){
            // mandar evento de stun
            Debug.Log("Combo!");
            _attackCount = 0;
        }
    }

    private IEnumerator Slice()
    {
        _knife.enabled = true;
        _knifeCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _knife.enabled = false;
        _knifeCollider.enabled = false;
    }

    private void OnTriggerEnter2D (Collider2D other){
        var _enemyHealth = other.gameObject.GetComponentInParent<EnemyHealthHandler>();
        if (_enemyHealth != null){
            _enemyHealth.TakeDamage(_damage);
        }
    }
}