using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float _speed = 100f;
    public float _lifeTime = 1f;
    public float _dyingDistance = 0.1f;

    private Vector3 direction = Vector3.right;
    private float _currentLife;
    private Vector3 _targetPosition;
    private bool _shouldDie;

    void Start()
    {
        _currentLife = 1f;
        _shouldDie = false;
    }
    void Update()
    {
        transform.position = transform.position + direction * _speed * Time.deltaTime;

        _currentLife -= Time.deltaTime;
        _shouldDie = (Vector2.Distance(_targetPosition, transform.position) <= _dyingDistance) || (_currentLife <= 0);
        if (_shouldDie)
            Destroy(gameObject);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        direction = (targetPosition - transform.position).normalized;
    }
}