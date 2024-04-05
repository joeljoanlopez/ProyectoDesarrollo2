using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{
    // Start is called before the first frame update
    public Light _targetLight;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Turn off the light if it's currently on
            if (_targetLight != null && _targetLight.enabled)
            {
                _targetLight.enabled = false;
            }
            else if (_targetLight != null && !_targetLight.enabled)
            {
                _targetLight.enabled = true;
            }
        }
    }
}

