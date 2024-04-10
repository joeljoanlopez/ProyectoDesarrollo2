using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{
    public float _battery = 100;

    private Light2D _light;
    private bool _canLight = true;
    private bool _flashEnabled = false;


    private void Start()
    {
        _light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_canLight)
        {
            // Check if the "F" key is pressed
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Change enabled state
                _flashEnabled = !_flashEnabled;
            }

            if (_flashEnabled)
            {
                _light.intensity = 1;
                _battery -= 0.1f * Time.deltaTime;
            }
            else
            {
                _light.intensity = 0;
            }

            if (_battery <= 0)
                _canLight = false;
        }
        else
        {
            _light.intensity = 0;
        }
    }
}