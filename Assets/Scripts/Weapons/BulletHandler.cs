using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float _speed = 100f;
    public float _lifeTime = 1f;
    public float _deathMargin = 0.5f;

    private Vector3 _direction = Vector3.right;
    private float _currentLife;
    private Vector3 _target;

    void Start()
    {
        _currentLife = _lifeTime;
    }
    void Update()
    {
        transform.position = transform.position + _direction * _speed * Time.deltaTime;

        _currentLife -= Time.deltaTime;
        if (_currentLife <= 0)
            Destroy(gameObject);
        if (Vector3.Distance(transform.position, _target) <= _deathMargin){
            Destroy(gameObject);
        }
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _target = targetPosition;
        _direction = (targetPosition - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}