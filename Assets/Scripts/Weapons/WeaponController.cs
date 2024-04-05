using System;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnAttack;

    public float _coolDown;
    private float _currentCoolDown;

    private bool _isAiming;
    public bool Aiming { get { return _isAiming; } }

    void Start()
    {
        _currentCoolDown = _coolDown;
    }

    void Update()
    {
        _isAiming = Input.GetMouseButton(1);
        if (_isAiming)
        {
            transform.rotation = GetRotation();
            if (Input.GetMouseButtonDown(0))
            {
                if (_currentCoolDown <= 0f)
                {
                    OnAttack?.Invoke();
                    _currentCoolDown = _coolDown;
                }
            }
        }

        _currentCoolDown -= Time.deltaTime;
    }

    private Quaternion GetRotation()
    {
        //Get the Screen positions of the object and the mouse
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = GetAngleFromPoints(mouseOnScreen, positionOnScreen);

        //return the rotation
        return Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float GetAngleFromPoints(Vector3 a, Vector3 b)
    {
        return MathF.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
