using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float _speed = 100f;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    Vector3 direction;
    void Start()
    {
        _startPosition = transform.position;
        _startPosition.z -= 1;
    }
    void Update()
    {
        transform.position = transform.position + direction * _speed * Time.deltaTime;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;
        _targetPosition = targetPosition;
        _targetPosition.z -= 1;
    }
}