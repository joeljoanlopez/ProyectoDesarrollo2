using UnityEngine;

public class HearingDetector : MonoBehaviour {
    public GameObject _player;
    public float _detectionRange = 10f;
    private bool _detected;
    public bool Detected {get {return _detected;}}
}