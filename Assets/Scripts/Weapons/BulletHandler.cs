using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float _speed = 100f;
    public float _lifeTime = 1;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 direction = Vector3.right;
    private float _currentLife;
    private GameObject[] _enemies;
    
    void Start()
    {
        _startPosition = transform.position;
        _currentLife = 1f;
    }
    void Update()
    {
        transform.position = transform.position + direction * _speed * Time.deltaTime;

        _currentLife -= Time.deltaTime;
        if(_currentLife <= 0)
            Destroy(gameObject);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;
        _targetPosition = targetPosition;
    }
}