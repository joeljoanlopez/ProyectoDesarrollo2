using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject _levelParent;
    [SerializeField]private GameObject[] _levels;
    [SerializeField]private Light[][] _lights;
    private int _levelNumber;

    private void Start() {
        _levelNumber = _levelParent.transform.childCount;
        _levels = new GameObject[_levelNumber];
        _lights = new Light [_levelNumber][];
        for (int i = 0; i < _levelNumber; i++){
            _levels[i] = _levelParent.transform.GetChild(i).gameObject;
            _lights[i] = GetComponentsInChildren<Light>();
        }
    }
}