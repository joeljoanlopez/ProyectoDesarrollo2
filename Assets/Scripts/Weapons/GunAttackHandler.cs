using UnityEngine;

public class GunAttackHandler : MonoBehaviour
{
    public float _aimDistance = 100f;

    private LineRenderer _aimRay;

    private void Start()
    {
        _aimRay = GetComponent<LineRenderer>();
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