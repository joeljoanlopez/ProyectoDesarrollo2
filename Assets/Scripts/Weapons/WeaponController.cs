using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnAttack;
    public float _coolDown;

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

        _currentCoolDown -= Time.deltaTime;
    }
}