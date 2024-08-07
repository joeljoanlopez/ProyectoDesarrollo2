using System;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Waypoint _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distChange = 0.01f;
    [SerializeField] private Transform _currentWP;

    private bool _moving;
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
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_currentWP.position.x, transform.position.y), _speed * Time.deltaTime);
    }

    public void NextWP()
    {
        StopMove();
        _currentWP = _waypoints.GetNextWP(_currentWP);
    }

    public bool ArrivedAtWP()
    {
        return Math.Abs(transform.position.x - _currentWP.position.x) < _distChange;
    }

    public void Move()
    {
        _moving = true;
    }

    public void StopMove()
    {
        _moving = false;
    }

    public Transform GetNextTransform(){
        return _currentWP;
    }
}