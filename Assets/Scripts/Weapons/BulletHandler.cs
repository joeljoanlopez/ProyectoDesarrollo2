using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float _speed = 100f;
    public float _lifeTime = 1f;

    private Vector3 direction = Vector3.right;
    private float _currentLife;

    void Start()
    {
        _currentLife = _lifeTime;
    }
    void Update()
    {
        transform.position = transform.position + direction * _speed * Time.deltaTime;

        _currentLife -= Time.deltaTime;
        if (_currentLife <= 0)
            Destroy(gameObject);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}