using UnityEngine;
using UnityEngine.Rendering;

public class GunAttackHandler : MonoBehaviour
{
    public float _aimDistance = 100f;
    public Transform _gunPoint;
    public GameObject _bulletTrail;
    public float _damage = 0;
    public int _ammo = 6;
    public int _maxAmmo = 6;
    public int _mags = 0;
    public TextPopUpManager _text;

    private float _holdDuration = 0;
    private WeaponHolderController _controller;
    private LineRenderer _aimRay;
    private bool _messageShown = false;


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

        if (Input.GetKey(KeyCode.R))
            _holdDuration += Time.deltaTime;

        if (_holdDuration >= 1 && !_messageShown)
        {
            if (_mags > 3)
                _text.ShowText(_mags + " mags and " + _ammo + " in the chamber, will do for now");
            else if (_ammo <= 0 && _mags <= 0)
                _text.ShowText("I have nothing left, Shit...");
            else
                _text.ShowText(_mags + " mags and " + _ammo + " in the chamber, I'm running low");
            _messageShown = true;
        }
        else if (Input.GetKeyUp(KeyCode.R) && _holdDuration < 1 && _ammo < 10 && _mags > 0)
        {
            _mags -= 1;
            _ammo = _maxAmmo;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _holdDuration = 0;
            _messageShown = false;
        }

    }

    public void Shoot()
    {
        if (_ammo > 0)
        {
            _ammo -= 1;
            var _hit = Physics2D.Raycast(_gunPoint.position, transform.right, _aimDistance);
            var _trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);
            _trail.transform.SetParent(transform);
            var _trailScript = _trail.GetComponent<BulletHandler>();

            if (_hit.collider)
            {
                _trailScript.SetTargetPosition(_hit.point);

                // Make damage
                var _enemyHealth = _hit.transform.GetComponent<EnemyHealthHandler>();
                var _lootBoxHealth = _hit.transform.GetComponent<LootBoxHealth>();
                if (_enemyHealth != null)
                {
                    float _damageMultiplier = 1.0f;
                    string hitboxTag = _hit.collider.tag;
                    switch (hitboxTag)
                    {
                        case "Head":
                            _damageMultiplier = 1.5f;
                            break;
                        case "Torso":
                            _damageMultiplier = 1.0f;
                            break;
                        case "Limbs":
                            _damageMultiplier = 0.8f;
                            break;
                    }
                    _enemyHealth.TakeDamage(_damage * _damageMultiplier);
                }
                else if (_lootBoxHealth != null)
                {
                    _lootBoxHealth.TakeDamage(_damage);
                }
            }
            else
            {
                var _endPosition = _gunPoint.position + transform.right * _aimDistance;
                _trailScript.SetTargetPosition(_endPosition);
            }

        }
        else
        {
            _text.ShowText("Out of ammo");

        }
    }

    public void GetAmmo(int value)
    {
        _mags += value;
    }
}