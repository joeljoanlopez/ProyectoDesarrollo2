using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed = 10f;
    public float _detectionRange = 10;
    public float _attackDistance = 3f;
    public Collider2D _collider;

    private GameObject _player;
    private HidingController _hidingController;
    private float _distance;
    public float Distance { get { return _distance; } }
    private bool _hiding;
    public bool Hiding { get { return _hiding; } }
    [SerializeField] private int _room;
    public int Room { get { return _room; } }
    private GameObject _gm;
    private RoomHandler _roomHandler;
    AudioManager _audioManager;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _hidingController = _player.GetComponent<HidingController>();
        _gm = GameObject.FindWithTag("GameManager");
        _roomHandler = _gm.GetComponent<RoomHandler>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _room = _roomHandler.GetLevelNumber(_collider);
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        _hiding = !_hidingController.Targettable || (_room != _roomHandler.PlayerLevel());
        if (_room == _roomHandler.PlayerLevel() && !_hiding)
        {
            _audioManager.ChangeMusic(_audioManager.CombatAlways);
        }

        bool _facingRight = _rb.velocity.x > 0;
        if (_facingRight)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public Vector3 PlayerDirection()
    {
        Vector3 _direction = new Vector3(_player.transform.position.x - transform.position.x, 0, 0);
        if (_direction.x < 0) _direction.x = -1;
        else if (_direction.x > 0) _direction.x = 1;
        return _direction;
    }

}
