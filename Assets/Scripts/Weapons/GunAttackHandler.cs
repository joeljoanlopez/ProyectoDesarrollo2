using UnityEngine;

public class GunAttackHandler : MonoBehaviour
{
    public float _aimDistance = 100f;
    public int _maxBulletsOnScreen = 5;
    public GameObject[] _bulletPool;
    public GameObject _bullet;

    private LineRenderer _aimRay;

    private void Start()
    {
        _aimRay = GetComponent<LineRenderer>();

        // Create an Object Pool and instantiate bullets
        _bulletPool = new GameObject[_maxBulletsOnScreen];
        for (int i = 0; i < _bulletPool.Length; i++)
        {
            _bulletPool[i] = Instantiate(_bullet);
            _bulletPool[i].transform.SetParent(transform, false);
            _bulletPool[i].SetActive(false);
        }
    }

    public void Shoot()
    {
        print("PUM PUM");
    }

    public void Update()
    {
        Debug.Assert(_aimRay);
        Vector3 _aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _aimDirection.z = 0;

        _aimRay.SetPosition(0, transform.position);
        _aimRay.SetPosition(1, _aimDirection.normalized * _aimDistance);
    }
}