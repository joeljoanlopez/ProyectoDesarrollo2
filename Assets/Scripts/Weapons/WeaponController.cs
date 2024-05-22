using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnAttack;
    public float _coolDown = 1f;
    public float _damage = 0;
    public GameObject _GunArm;

    private WeaponHolderController _controller;
    private float _currentCoolDown;

    private void Start()
    {
        _currentCoolDown = _coolDown;
        _controller = GetComponentInParent<WeaponHolderController>();
    }

    private void Update()
    {
        if (_controller.Aiming && Input.GetMouseButtonDown(0))
        {
            if (_currentCoolDown <= 0f)
            {
                OnAttack?.Invoke();
                _currentCoolDown = _coolDown;
            }
        }

        if (_GunArm != null)
            _GunArm.SetActive((_controller.CurrentWeaponIndex == 1) && (_controller.Aiming));

        _currentCoolDown -= Time.deltaTime;
    }
}