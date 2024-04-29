using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _player;
    public GameObject _enemy;
    private EnemyAttackHandler _attackHandler;
    public float _speed;
    public float _detectionRange = 10;
    public bool _detected;

    private float _distance;

    void Start()
    {
        _detected = false;
        _attackHandler = _enemy.GetComponent<EnemyAttackHandler>();
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        Vector2 direction = _player.transform.position - transform.position;
        var _detectionCalc = Math.Abs(_player.GetComponent<Rigidbody2D>().velocity.x) / _distance * 25;
        if (_detectionRange < _detectionCalc)
        {
            _detected = true;
        }
        if (_detected && _distance <= 3 && _player.GetComponent<MovementController>()._canMove)
        {
            StartCoroutine(_attackHandler.Strike()); // Call Strike() coroutine here
        }
        else if (_detected && _player.GetComponent<MovementController>()._canMove)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
        }

    }

}
