using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    public float _damage = 30;
    // public float _cooldown = 2f;

    private SpriteRenderer _claw;
    private Collider2D _clawCollider;
    private float _timer;
    
    void Start()
    {
        _claw = GetComponent<SpriteRenderer>();
        _claw.enabled = false;
        _clawCollider = GetComponent<Collider2D>();
        _clawCollider.enabled = false;
        // _timer = _cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        _timer = _timer - Time.deltaTime;
    }

    public void DoStrike()
    {
        StartCoroutine(Strike());
    }

    public IEnumerator Strike()
    {
        if (_timer <= 0)
        {
            _claw.enabled = true;
            _clawCollider.enabled = true;
            yield return new WaitForSeconds(0.1f);
            _claw.enabled = false;
            _clawCollider.enabled = false;
            // _timer = _cooldown;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var _targetHealth = other.gameObject.GetComponentInParent<HealthManager>();
        if (_targetHealth != null)
        {
            _targetHealth.RemoveHealth(_damage);
        }
    }
}
