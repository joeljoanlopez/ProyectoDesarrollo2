using UnityEngine;

public class GunAttackHandler : MonoBehaviour
{
    public float _aimDistance = 100f;
    public Transform _gunPoint;
    public GameObject _bulletTrail;

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
        var _hit = Physics2D.Raycast(_gunPoint.position, _aimDirection, _aimDistance);
        var _trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);
        var _trailScript = _trail.GetComponent<BulletHandler>();

        if (_hit.collider)
        {
            _trailScript.SetTargetPosition(_hit.point);
        }
    }

    public void Update()
    {
        // Calculate _aimDirection
        _aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _aimDirection.z = 0;

        // Set the _aimRay direction and show if needed
        _aimRay.SetPosition(0, transform.position);
        _aimRay.SetPosition(1, _aimDirection.normalized * _aimDistance);
        _aimRay.enabled = _controller.enabled;
    }
}