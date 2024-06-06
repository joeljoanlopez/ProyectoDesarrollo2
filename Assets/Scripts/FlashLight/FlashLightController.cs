using UnityEngine;
using UnityEngine.Rendering.Universal;
public class FlashLightController : MonoBehaviour
{
    public float _battery = 100;
    public GameObject _lantern;

    private bool _flashEnabled;

    private void Start()
    {
        _flashEnabled = true;
        _lantern.SetActive(true);
    }

    private void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the enabled state
            _flashEnabled = !_flashEnabled;
            _lantern.SetActive(_flashEnabled);
        }

        // Reduce battery if the flashlight is on
        if (_flashEnabled)
        {
            _battery -= 5f * Time.deltaTime;
            if (_battery <= 0)
            {
                _battery = 0;
                _flashEnabled = false;
                _lantern.SetActive(false);
            }
        }
    }

    public void AddBattery(int value)
    {
        _battery += value;
        if (_battery > 0 && !_flashEnabled)
        {
            _flashEnabled = true;
            _lantern.SetActive(true);
        }
    }
}