using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool _smooth = true;
    [SerializeField] private Transform _target;
    private Vector3 _offset = new Vector3(0, 2, -10);
    private float _smoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (_smooth)
        {
            Vector3 targetPosition = _target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
        else
        {
            transform.position = _target.position + _offset;
        }
    }
}
