using System;
using Unity.Mathematics;
using UnityEngine;

public class WeaponHolderController : MonoBehaviour
{
    public GameObject _lantern;
    public float _maxAimAngle = 30;
    public GameObject _GunArmRight;
    public GameObject _GunArmLeft;
    public bool _canAim = true;

    private MovementController _movementController;
    private GameObject[] _weapons;
    private int _totalWeapons;
    private Animator _animator;
    private bool _isAiming;
    public bool Aiming
    { get { return _isAiming; } }
    private int _currentWeaponIndex = 0;
    public int CurrentWeaponIndex { get { return _currentWeaponIndex; } }

    private void Start()
    {
        _movementController = GetComponentInParent<MovementController>();
        // Get number of weapons and initialize array
        _totalWeapons = transform.childCount;
        _weapons = new GameObject[_totalWeapons];

        // Fill array with weapons
        for (int i = 0; i < _totalWeapons; i++)
        {
            _weapons[i] = transform.GetChild(i).gameObject;
            _weapons[i].SetActive(false);
        }

        // Set current weapon
        _weapons[_currentWeaponIndex].SetActive(true);
        _animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _animator.SetInteger("WhatWeapon", 0);
            ChangeWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _animator.SetInteger("WhatWeapon", 1);
            ChangeWeapon(1);
        }

        _lantern.transform.rotation = _movementController.FacingRight ? Quaternion.Euler(Vector3.back * 90) : Quaternion.Euler(Vector3.forward * 90);
        _GunArmRight.SetActive(false);
        _GunArmLeft.SetActive(false);

        _isAiming = _canAim && Input.GetMouseButton(1);
        if (_isAiming)
        {
            if (_currentWeaponIndex == 1)
            {
                transform.rotation = GetRotation();
                _GunArmRight.SetActive(_movementController.FacingRight);
                _GunArmLeft.SetActive(!_movementController.FacingRight);
            }
            else
            {
                transform.rotation = _movementController.FacingRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.forward * 180);
            }
        }
    }

    private Quaternion GetRotation()
    {
        //Get the Screen positions of the object and the mouse
        Vector3 mouseOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mouseOnScreen - transform.position;
        float angle = MathF.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        if (_movementController.FacingRight)
        {
            if (angle > _maxAimAngle)
                angle = _maxAimAngle;
            else if (angle < -_maxAimAngle)
                angle = -_maxAimAngle;
        }
        else
        {
            if (angle > -(180 - _maxAimAngle) && angle < -90)
                angle = -(180 - _maxAimAngle);
            else if (angle < (180 - _maxAimAngle) && angle > 90)
                angle = 180 - _maxAimAngle;
        }

        //return the angle
        return Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void ChangeWeapon(int index)
    {
        _weapons[_currentWeaponIndex].SetActive(false);

        _currentWeaponIndex = index;
        _weapons[_currentWeaponIndex].SetActive(true);
    }
}