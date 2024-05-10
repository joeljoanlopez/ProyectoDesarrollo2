using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public bool _smooth = false;
    [SerializeField] private Transform _target;
    private Vector3 _offset = new Vector3(0, 2, -10);
    private float _smoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;
    float xOffset = 0; 

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            // Calculate the target position with the offset
            Vector3 targetPosition = _target.position + _offset;

            // Calculate the offset based on the player's horizontal movement
            if (_target.GetComponent<MovementController>()._horizontal != 0){
                xOffset = _target.GetComponent<MovementController>()._horizontal * 3;
            }
            else
            {
                xOffset = xOffset;
            }

            // Apply the horizontal offset
            targetPosition.x += xOffset;
            if (_smooth)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
            }
            else
            {
                transform.position = _target.position + _offset;
            }
        }
    }
}
