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
    public float _horizontal;
    public float _walkingSpeed = 4f;
    public float _runningSpeed = 8f;
    public float _aimingSpeed = 2f;
    private float _aimDelay;
    private bool _isFacingRight = true;

    AudioManager _audioManager;
    public bool FacingRight { get { return _isFacingRight; } }
    private bool _isAiming = false;
    public bool _canMove;
    Animator _animator;
    public float _speed;
    public float _timer;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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
            _horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (_speed > _aimingSpeed)
                {
                    _speed -= 0.5f;
                }
                else
                {
                    _speed += 0.5f;
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
            if (_horizontal !=0)
            {
                float stepvolume = 2.0f;
                if (_speed == 8)
                {
                    if (_timer <= 0.35f)
                    {
                        _timer += Time.deltaTime;
                    }
                    else
                    {
                        _audioManager.PlaySFX(_audioManager.Step, stepvolume);
                        _timer = 0.0f;
                    }
                }
                else if (_speed == 4)
                {
                    if (_timer <= 0.5f)
                    {
                        _timer += Time.deltaTime;
                    }
                    else
                    {
                        _audioManager.PlaySFX(_audioManager.Step, stepvolume);
                        _timer = 0.0f;
                    }
                }
                else if (_speed == 2)
                {
                    if (_timer <= 0.8f)
                    {
                        _timer += Time.deltaTime;
                    }
                    else
                    {
                        _audioManager.PlaySFX(_audioManager.Step, stepvolume);
                        _timer = 0.0f;
                    }
                }

            }

            Flip();
        }
        else
        {
            _horizontal = 0f;
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
        if (!_isAiming && ((_isFacingRight && (_horizontal < 0f)) || (!_isFacingRight && (_horizontal > 0f))))
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
