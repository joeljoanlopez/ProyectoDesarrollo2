using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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

    AudioManager _audioManager;
    Animator _animator;

    private float _holdDuration = 0;
    private WeaponHolderController _controller;
    private LineRenderer _aimRay;
    private bool _messageShown = false;
    public Light2D _light;
    public GameObject _particles;
    private float _timer = 0;
    private bool _recharge;
    private bool _checkrecharge;
    private MovementController _movement;
    private GameObject[] _enemies;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _movement = GetComponentInParent<MovementController>();
    }

    private void Start()
    {
        _aimRay = GetComponent<LineRenderer>();
        _controller = GetComponentInParent<WeaponHolderController>();
        _light.intensity = 0;
        _particles.SetActive(false);
        _animator = GetComponentInParent<Animator>();
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.R))
            _holdDuration += Time.deltaTime;

        if (_holdDuration >= 1 && !_messageShown)
        {
            _controller._canAim = false;
            _checkrecharge = true;
            _movement._canMove = false;
            if (_mags > 3)
                _text.ShowText(_mags + " mags and " + _ammo + " in the chamber, will do for now");
            else if (_ammo <= 0 && _mags <= 0)
                _text.ShowText("I have nothing left, Shit...");
            else
                _text.ShowText(_mags + " mags and " + _ammo + " in the chamber, I'm running low");
            _messageShown = true;
            _animator.SetBool("IsChecking", true);
            _timer = 0;
        }
        else if (Input.GetKeyUp(KeyCode.R) && _holdDuration < 1 && _ammo < 10 && _mags > 0)
        {
            _controller._canAim = false;
            _audioManager.PlaySFX(_audioManager.Recharge);
            _animator.SetBool("IsRecharging", true);
            _movement._canMove = false;
            _recharge = true;
            _mags -= 1;
            _ammo = _maxAmmo;
            _timer = 0;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _holdDuration = 0;
            _messageShown = false;

        }
        if (_light.intensity > 0)
        {
            _light.intensity -= 0.5f;
        }
        if (_light.intensity <= 0)
        {
            _particles.SetActive(false);
        }

        if (_recharge)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1.20)
            {
                _animator.SetBool("IsRecharging", false);
                _recharge = false;
                _movement._canMove = true;
                _timer = 0;
                _controller._canAim = true;
            }
        }
        if (_checkrecharge)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1.20)
            {
                _animator.SetBool("IsChecking", false);
                _checkrecharge = false;
                _timer = 0;
                _movement._canMove = true;
                _controller._canAim = true;
            }
        }
    }

    private void FixedUpdate()
    {
        // Set the _aimRay direction and show if needed
        _aimRay.enabled = false;
        if (_controller.Aiming)
        {
            _aimRay.SetPosition(0, _gunPoint.position);
            RaycastHit2D[] _hit = Physics2D.LinecastAll(_gunPoint.position, transform.right * _aimDistance);
            Debug.DrawLine(transform.position, transform.right * _aimDistance, Color.blue);
            for (int i = 0; i < _hit.Length; i++)
            {
                if ((_hit[i].transform.tag == "Enemy") || (_hit[i].transform.tag == "Wall"))
                {
                    _aimRay.SetPosition(1, _hit[i].point);
                }
                else
                {
                    _aimRay.SetPosition(1, transform.right * _aimDistance);
                }
            }
            _aimRay.enabled = true;
        }
    }

    public void Shoot()
    {
        if (_ammo > 0)
        {
            _audioManager.PlaySFX(_audioManager.GunShot);
            _audioManager.PlaySFX(_audioManager.ShellHittingDown);
            _ammo -= 1;
            _light.intensity = 10;
            _particles.SetActive(true);

            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].GetComponent<Animator>().SetTrigger("Chase");
            }

            var _trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);
            var _trailScript = _trail.GetComponent<BulletHandler>();
            RaycastHit2D[] _hit = Physics2D.LinecastAll(_gunPoint.position, transform.right * _aimDistance);
            for (int i = 0; i < _hit.Length; i++)
            {
                if (_hit[i].transform.tag == "Enemy")
                {
                    print("BOOM");
                    _trailScript.SetTargetPosition(_hit[i].point);

                    // Make damage
                    var _enemyHealth = _hit[i].transform.GetComponent<EnemyHealthHandler>();
                    var _lootBoxHealth = _hit[i].transform.GetComponent<LootBoxHealth>();
                    if (_enemyHealth != null)
                    {
                        float _damageMultiplier = 1.0f;
                        string hitboxTag = _hit[i].collider.tag;
                        switch (hitboxTag)
                        {
                            case "Head":
                                _damageMultiplier = 2f;
                                break;
                            case "Torso":
                                _damageMultiplier = 1.5f;
                                break;
                            case "Limbs":
                                _damageMultiplier = 1.0f;
                                break;
                        }
                        _enemyHealth.TakeDamage(_damage * _damageMultiplier);
                    }
                    else if (_lootBoxHealth != null)
                    {
                        _lootBoxHealth.TakeDamage(_damage);
                    }
                }
                else if (_hit[i].transform.tag == "Wall")
                {
                    _trailScript.SetTargetPosition(_hit[i].point);
                }
                else
                {
                    var _endPosition = _gunPoint.position + transform.right * _aimDistance;
                    _trailScript.SetTargetPosition(_endPosition);
                }
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