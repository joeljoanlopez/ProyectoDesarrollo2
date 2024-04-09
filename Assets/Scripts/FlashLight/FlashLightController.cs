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
            // Turn off the light if it's currently on
            if (_targetLight != null && _targetLight.enabled)
            {
                _targetLight.enabled = false;
                _enabled = false;
            }
            else if (_targetLight != null && !_targetLight.enabled && _battery > 0)
            {
                _targetLight.enabled = true;
                _enabled = true;
            }
        }
        if (_enabled == true)
        {
            _battery -= 0.1f;
        }
        //if (_battery < 0 && _canLight)
        //{
         //   _targetLight.enabled = false;
          //  _canLight = false;
        //}
    }
}

