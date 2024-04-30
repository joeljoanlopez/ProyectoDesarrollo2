using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _player;
    public float _speed = 10f;
    public float _detectionRange = 10;
    public float _attackDistance = 3f;

    private float _distance;
    public float Distance { get { return _distance; } }

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
    }

    public Vector3 PlayerDirection()
    {
        Vector3 _direction = (Vector2)(_player.transform.position - transform.position).normalized;
        return _direction;
    }

}
