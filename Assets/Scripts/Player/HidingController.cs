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

    private GameObject _enemy;
    private MovementController _movementController;

    public void Start()
    {
        _hiding = false;
        _movementController = GetComponent<MovementController>();
        _enemy = GameObject.FindWithTag("Enemy");
    }
    
    private void Update()
    {
        if (_canHide && Input.GetKeyDown(KeyCode.E))
            _hiding = !_hiding;


        if (_hiding)
        {
            SetTransparency(_hidingTransparency);
            _movementController._canMove = false;
            Physics2D.IgnoreLayerCollision(gameObject.layer, _enemy.layer, true);
        }
        else
        {
            SetTransparency(1f);
            _movementController._canMove = true;
            Physics2D.IgnoreLayerCollision(gameObject.layer, _enemy.layer, false);
        }
    }

    private void SetTransparency(float value)
    {
        Renderer renderer = GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = value;
        renderer.material.color = color;
    }
}


