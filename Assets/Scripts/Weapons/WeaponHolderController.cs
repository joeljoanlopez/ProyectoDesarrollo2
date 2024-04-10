using System;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponHolderController : MonoBehaviour
{
    public GameObject _lantern;

    private int _currentWeaponIndex = 0;
    private GameObject[] _weapons;
    private GameObject _currentWeapon;
    private int _totalWeapons;

    private bool _isAiming;

    public bool Aiming
    { get { return _isAiming; } }

    private void Start()
    {
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
        _currentWeapon = _weapons[_currentWeaponIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapon(0);

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(1);


        _isAiming = Input.GetMouseButton(1);
        if (_isAiming)
        {
            transform.rotation = GetRotation();
            _lantern.transform.rotation = GetRotation();
        }
    }

    private Quaternion GetRotation()
    {
        //Get the Screen positions of the object and the mouse
        Vector3 mouseOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mouseOnScreen - transform.position;
        float angle = MathF.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

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