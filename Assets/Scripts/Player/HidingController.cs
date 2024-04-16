using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HidingController : MonoBehaviour
{
    // Start is called before the first frame update

    public  GameObject _player;
    private bool _isActive;
    public bool _targeteable;
    public bool _isTransparent;
    public float _transparencyValue;
    

    public void Start()
    {
        _isActive = false;
        _targeteable = true;
    }
    private void Update()
    {
        if (_isActive && Input.GetKeyDown(KeyCode.E))
        {
            _isTransparent = !_isTransparent;
        }
        if (_isTransparent)
        {
            _targeteable = true;
            SetTransparency(0.5f);
            _player.GetComponent<MovementController>()._canMove = false;
        }
        else
        {
            SetTransparency(1f);
            _targeteable = false;
            _player.GetComponent<MovementController>()._canMove = true;
        }
    }
    private void SetTransparency(float transparencyValue)
    {
        Renderer renderer = _player.GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = transparencyValue;
        renderer.material.color = color; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == _player.name)
        {
            _isActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _isActive = false;
    }

}


