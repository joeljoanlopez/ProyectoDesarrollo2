using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
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
    private SpriteRenderer _sprite;
    private float _xPre;
    private AudioSource _enemyAudioSource;
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
        _sprite = GetComponent<SpriteRenderer>();
        _enemyAudioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        bool isPlayerInSameRoom = (_room == _roomHandler.PlayerLevel() && !_hiding);

        _room = _roomHandler.GetLevelNumber(_collider);
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        _hiding = !_hidingController.Targettable || (_room != _roomHandler.PlayerLevel());

        if (isPlayerInSameRoom)
        {
            _enemyAudioSource.clip = _audioManager.Combat;
            if (!_enemyAudioSource.isPlaying)
            {
                _enemyAudioSource.Play();
            }
        }
        else
        {
            _enemyAudioSource.Stop();
        }
    }

    public Vector3 PlayerDirection()
    {
        Vector3 _direction = new Vector3(_player.transform.position.x - transform.position.x, 0, 0);
        if (_direction.x < 0) _direction.x = -1;
        else if (_direction.x > 0) _direction.x = 1;
        return _direction;
    }
}
