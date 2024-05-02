using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private WeaponController _weaponController;
    private float _horizontal;
    public float _speed = 4f;
    private float _aimDelay;
    private bool _isFacingRight = true;
    private bool _isAiming = false;
    private float _currentDelay = 0;
    public bool _canMove;
    Animator _animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        _animator = GetComponent<Animator>();   
        _weaponController = GetComponentInChildren<WeaponController>();
        rb.velocity = new Vector2(_horizontal * _speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_canMove)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (_speed > 2.0f)
                {
                    _speed -= 0.5f;
                }
                else
                {
                    _isAiming = true;
                }
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = 8f;
                _isAiming = false;
            }
            else
            {
                _speed = 4f;
                _isAiming = false;
            }
            _horizontal = Input.GetAxisRaw("Horizontal");

            Flip();
        }
        else
        {
            _speed = 0f;
            Flip();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_horizontal * _speed, rb.velocity.y);
        if (_isAiming)
        {
            _animator.SetBool("IsAiming", true);
        }
        else if (!_isAiming) 
        {
            _animator.SetBool("IsAiming", false);
        }
        if(_horizontal != 0)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
    private void Flip()
    {
        if (_isAiming == false && (_isFacingRight && (_horizontal < 0f) || !_isFacingRight && (_horizontal > 0f)))
        {
            if (_currentDelay < _speed)
            {
                _currentDelay += 0.5f;
            }
            else
            {
                _isFacingRight = !_isFacingRight;
                // Vector3 _localScale = transform.localScale;
                // _localScale.x = -_localScale.x;
                // transform.localScale = _localScale;
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                _currentDelay = 0f;
            }
        }
    }
}
