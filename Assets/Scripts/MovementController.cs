using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float _horizontal;
    private float _speed = 4f;
    private bool _isFacingRight = true;
    private bool _isAiming = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _isAiming = true;
            _speed = 1.0f;
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
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_horizontal * _speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (_isAiming == false && (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f))
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        }
    }
}
