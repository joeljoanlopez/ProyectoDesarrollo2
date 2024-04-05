using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnAttack;

    public float _coolDown;
    private float _currentCoolDown;

    private bool _isAiming;
    public bool Aiming { get { return _isAiming; } }

    // Use this for initialization
    void Start()
    {
        _currentCoolDown = _coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        _isAiming = Input.GetMouseButton(1);
        if (_isAiming && Input.GetMouseButtonDown(0))
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
