using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public float _speed = 40f;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _progress;

    void Start()
    {
        _startPosition = transform.position;
        _startPosition.z -= 1;
    }
    void Update()
    {
        _progress = Time.deltaTime;
        transform.position = Vector3.Lerp(_startPosition, _targetPosition, _progress);
    }

    public void SetTargetPosition(Vector3 targetPosition){
        _targetPosition = targetPosition;
        _targetPosition.z -= 1;
    }
}
