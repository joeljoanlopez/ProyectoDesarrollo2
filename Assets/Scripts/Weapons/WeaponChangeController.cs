using System;
using UnityEngine;

public class WeaponChangeController : MonoBehaviour
{
    [SerializeField] int _currentWeaponIndex = 0;

    private GameObject[] _weapons;
    private GameObject _currentWeapon;
    int _totalWeapons;

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
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            _weapons[_currentWeaponIndex].SetActive(false);

            // Check if nextWeapon is in the array
            int _nextWeapon = _currentWeaponIndex + 1;
            if (_nextWeapon >= _totalWeapons)
            {
                _nextWeapon = 0;
            }

            _currentWeaponIndex = _nextWeapon;
            _weapons[_currentWeaponIndex].SetActive(true);
        }
    }
}
