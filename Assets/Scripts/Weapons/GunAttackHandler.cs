using UnityEngine;
using UnityEngine.Rendering;

public class GunAttackHandler : MonoBehaviour
{
    public float _aimDistance = 100f;
    public Transform _gunPoint;
    public GameObject _bulletTrail;
    public float _damage = 0;
    public int _ammo = 10;

    private WeaponHolderController _controller;
    private LineRenderer _aimRay;


    private void Start()
    {
        _aimRay = GetComponent<LineRenderer>();
        _controller = GetComponentInParent<WeaponHolderController>();
    }

    public void Update()
    {
        // Set the _aimRay direction and show if needed
        _aimRay.SetPosition(0, _gunPoint.position);
        _aimRay.SetPosition(1, transform.right * _aimDistance);

        _aimRay.enabled = _controller.Aiming;
    }

    public void Shoot()
    {
        var _hit = Physics2D.Raycast(_gunPoint.position, transform.right, _aimDistance);
        var _trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);
        _trail.transform.SetParent(transform);
        var _trailScript = _trail.GetComponent<BulletHandler>();

        if (_hit.collider)
        {
            _trailScript.SetTargetPosition(_hit.point);

            // Make damage
            var _enemyHealth = _hit.transform.GetComponent<EnemyHealthHandler>();
            if (_enemyHealth != null){
                _enemyHealth.TakeDamage(_damage);
            }
        }
        else
        {
            var _endPosition = _gunPoint.position + transform.right * _aimDistance;
            _trailScript.SetTargetPosition(_endPosition);
        }
    }

    public void GetAmmo(int value){
        _ammo += value;
    }
}