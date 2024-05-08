using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private WeaponController _weaponController;
    private WeaponHolderController _weaponHolderController;
    private float _horizontal;
    public float _walkingSpeed = 4f;
    public float _runningSpeed = 8f;
    public float _aimingSpeed = 2f;
    private float _aimDelay;
    private bool _isFacingRight = true;
    public bool FacingRight { get { return _isFacingRight; } }
    private bool _isAiming = false;
    private float _currentDelay = 0;
    public bool _canMove;
    Animator _animator;
    private float _speed;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _weaponHolderController = GetComponentInChildren<WeaponHolderController>();
        rb.velocity = new Vector2(_horizontal * _speed, rb.velocity.y);
        _speed = _walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (_speed > _aimingSpeed)
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
                _speed = _runningSpeed;
                _isAiming = false;
            }
            else
            {
                _speed = _walkingSpeed;
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
        if (_horizontal != 0)
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
                // GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                transform.Rotate(0f, 180f, 0f);
                _currentDelay = 0f;
            }
        }
    }
}
