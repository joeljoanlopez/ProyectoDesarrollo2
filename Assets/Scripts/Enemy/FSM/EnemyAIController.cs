using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _player;
    public float _speed = 10f;
    public float _detectionRange = 10;
    public float _attackDistance = 3f;

    private HidingController _hidingController;
    private float _distance;
    public float Distance { get { return _distance; } }

    private bool _hiding;
    public bool Hiding { get { return _hiding; } }

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _hidingController = _player.GetComponent<HidingController>();
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        _hiding = !_hidingController.Targettable;
    }

    public Vector3 PlayerDirection()
    {
        Vector3 _direction = (Vector2)(_player.transform.position - transform.position).normalized;
        return _direction;
    }

}
