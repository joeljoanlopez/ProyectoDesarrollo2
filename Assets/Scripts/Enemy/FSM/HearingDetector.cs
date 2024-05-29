using System;
using UnityEngine;

public class HearingDetector : MonoBehaviour
{
    public float _detectionSound = 20f;
    private GameObject _player;
    private bool _detected;
    public bool Detected { get { return _detected; } }

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _detected = false;

    }

    private void Update()
    {
        var _distance = Vector2.Distance(transform.position, _player.transform.position);
        var _detectionCalc = Math.Abs(_player.GetComponent<Rigidbody2D>().velocity.x) / _distance * 25;
        _detected = _detectionSound < _detectionCalc;
    }
}