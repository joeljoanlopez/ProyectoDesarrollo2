using UnityEngine;

public class GunAttackHandler : MonoBehaviour
{
    public float _aimDistance = 100f;

    private WeaponHolderController _controller;
    private LineRenderer _aimRay;
    private Vector3 _aimDirection;

    private void Start()
    {
        _aimRay = GetComponent<LineRenderer>();
        _controller = GetComponentInParent<WeaponHolderController>();
    }

    public void Shoot()
    {

    }

    public void Update()
    {
        _aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _aimDirection.z = 0;

        _aimRay.SetPosition(0, transform.position);
        _aimRay.SetPosition(1, _aimDirection.normalized * _aimDistance);

        if (_controller.Aiming)
            _aimRay.enabled = true;
        else
            _aimRay.enabled = false;
    }
}