using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public bool _smooth = true;
    public Transform _target;
    private Vector3 _offset = new Vector3(0, 2, -10);
    private float _smoothTime = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            // Calculate the offset based on the player's horizontal movement
            if (_target.GetComponent<MovementController>()._horizontal != 0)
            {
                _offset.x = _target.GetComponent<MovementController>()._horizontal * 3;
            }

            if (_smooth)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smoothTime);
            }
            else
            {
                transform.position = _target.position + _offset;
            }
        }
    }
}
