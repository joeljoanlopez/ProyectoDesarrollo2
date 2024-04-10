using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private WeaponController _weaponController;
    private float _horizontal;
    private float _speed = 4f;
    private float _aimDelay;
    private bool _isFacingRight = true;
    private bool _isAiming = false;
    private float _currentDelay = 0;
    public bool _canMove;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
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
    }
    private void Flip()
    {
        if (_isAiming == false && (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f))
        {
            if (_currentDelay < _speed)
            {
                _currentDelay += 0.5f;
            }
            else
            {
                _isFacingRight = !_isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
                _currentDelay = 0f;
            }
        }
    }
}
