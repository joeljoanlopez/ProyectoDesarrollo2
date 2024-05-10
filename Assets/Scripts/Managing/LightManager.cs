using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Collider2D _player;
    public GameObject _levelParent;
    public float _lightOnIntensity = 0.1f;
    public float _lightOffIntensity = 0.05f;

    [SerializeField] private GameObject[] _levels;
    [SerializeField] private Light2D[][] _lights;
    private int _levelNumber;

    private void Start()
    {
        _levelNumber = _levelParent.transform.childCount;
        _levels = new GameObject[_levelNumber];
        _lights = new Light2D[_levelNumber][];

        for (int i = 0; i < _levelNumber; i++)
        {
            _levels[i] = _levelParent.transform.GetChild(i).gameObject;
            _lights[i] = _levels[i].GetComponentsInChildren<Light2D>();

            for (int j = 0; j < _lights[i].Length; j++)
            {
                _lights[i][j].enabled = false;
            }
        }
    }

    private void Update()
    {
        bool _found = false;
        int _currentLevel = 0;

        while (!_found && _currentLevel < _levels.Length)
        {
            Collider2D[] _colliders = _levels[_currentLevel].GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i].IsTouching(_player))
                    _found = true;
            }

            if (!_found) _currentLevel++;
        }

        for (int i = 0; i < _lights.Length; i++)
        {
            for (int j = 0; j < _lights[i].Length; j++)
            {
                // if (i == _currentLevel)
                // {
                //     if (_lights[i][j].lightType == Light2D.LightType.Freeform)
                //         _lights[i][j].intensity = _lightOnIntensity;
                //     else 
                //         _lights[i][j].enabled = true;
                // }
                // else
                // {
                //     if (_lights[i][j].lightType == Light2D.LightType.Freeform)
                //         _lights[i][j].intensity = _lightOffIntensity;
                //     else 
                //         _lights[i][j].enabled = false;
                // }
                _lights[i][j].enabled = (i == _currentLevel);
            }
        }
    }
}