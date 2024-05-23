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
    private int _room;
    private GameObject _gm;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _hidingController = _player.GetComponent<HidingController>();
        _gm = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        _hiding = !_hidingController.Targettable;
    }

    public Vector3 PlayerDirection()
    {
        Vector3 _direction = new Vector3(_player.transform.position.x - transform.position.x, 0, 0);
        if(_direction.x < 0) _direction.x = -1;
        else if (_direction.x > 0) _direction.x = 1;
        print(_direction);
        return _direction;
    }

}
