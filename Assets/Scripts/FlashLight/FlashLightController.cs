using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{
    // Start is called before the first frame update
    public Light2D _targetLight;
    public float _battery = 100;

    private bool _enabled = true;
    private bool _canLight = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F) && _canLight)
        {
            // Change TargetLight state
            if (_targetLight != null)
            {
                _targetLight.enabled = !_targetLight.enabled;
                _enabled = !_enabled;
            }
        }
        if (_enabled)
        {
            _battery -= 0.1f;
        }

        if (_battery <= 0)
        {
           _canLight = false;
        }

        if (!_canLight && _targetLight.enabled){
            _targetLight.enabled = false;
        }
    }
}

