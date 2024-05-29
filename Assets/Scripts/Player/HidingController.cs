using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HidingController : MonoBehaviour
{
    public bool _canHide = false;
    private bool _hiding;
    public bool Targettable { get { return !_hiding; } }
    public float _hidingTransparency = 0.5f;
    public float _currentTransparency = 1f;

    private GameObject _enemy;
    private MovementController _movementController;
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Start()
    {
        _hiding = false;
        _movementController = GetComponent<MovementController>();
        _enemy = GameObject.FindWithTag("Enemy");
    }

    private void Update()
    {
        if (_canHide && Input.GetKeyDown(KeyCode.E))
        {
            _hiding = !_hiding;
            if (!_hiding) _movementController._canMove = true;
        }
        _currentTransparency = _hiding ? _hidingTransparency : 1f;

        if (_hiding)
        {
            _audioManager.ChangeMusic(_audioManager.CombatHidden);
            _movementController._canMove = false;
        }
        else{
            _audioManager.ChangeMusic(_audioManager.DarkAmbienceA);
        }

        if (_enemy != null)
            Physics2D.IgnoreLayerCollision(gameObject.layer, _enemy.layer, _hiding);
        else
            _enemy = GameObject.FindWithTag("Enemy");

        SetTransparency(_currentTransparency);
    }

    private void SetTransparency(float value)
    {
        Renderer renderer = GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = value;
        renderer.material.color = color;
    }
}


