using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Waypoint _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distChange = 0.01f;

    private bool _moving;
    private Transform _currentWP;
    public Transform CurrentWP { get { return _currentWP; } }

    // Start is called before the first frame update
    private void Start()
    {
        _moving = false;
        //Set initial position
        _currentWP = _waypoints.GetNextWP(_currentWP);
        transform.position = _currentWP.position;
        _currentWP = _waypoints.GetNextWP(_currentWP);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_moving)
            transform.position = Vector2.MoveTowards(transform.position, _currentWP.position, _speed * Time.deltaTime);
    }

    public void NextWP()
    {
        StopMove();
        _currentWP = _waypoints.GetNextWP(_currentWP);
    }

    public bool ArrivedAtWP()
    {
        return Vector2.Distance(transform.position, _currentWP.position) < _distChange;
    }

    public void Move()
    {
        _moving = true;
    }

    public void StopMove()
    {
        _moving = false;
    }
}