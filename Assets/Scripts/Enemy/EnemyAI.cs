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
    public EnemyAttackHandler _attackHandler;
    public float _speed;
    public float _detectionRange = 10;
    public bool _detected;

    private float _distance;

    void Start()
    {
        _detected = false;
        _attackHandler = _enemy.GetComponent<EnemyAttackHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        print(_distance);
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        Vector2 direction = _player.transform.position - transform.position;
        if (_detectionRange < _player.GetComponent<MovementController>()._speed / _distance * 25)
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
