using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleportController : MonoBehaviour
{
    public Transform _player;
    public Transform _target;
    public bool _isClosed;
    public TextPopUpManager _text;
    public string _closedMessage = "It's closed";
    public UnityEvent _tryOpen;

    private GameObject _camera;
    private CameraFollow _cameraFollow;
    private bool _isActive;
    private Animator _fadeToBlack;

    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Start()
    {
        _isActive = false;
        _fadeToBlack = GameObject.FindWithTag("Curtain").GetComponent<Animator>();
        _camera = GameObject.FindWithTag("MainCamera");
        _cameraFollow = _camera.GetComponent<CameraFollow>();
    }

    private void Update()
    {
        if (_isActive && Input.GetKeyDown(KeyCode.E))
        {
            if (_isClosed)
                _text.ShowText(_closedMessage);
            else
            {
                _audioManager.PlaySFX(_audioManager.OpenCloseDoor);
                _fadeToBlack.SetTrigger("FadeStart");
                StartCoroutine(Teleport());
            }
            _tryOpen?.Invoke();
        }
    }

    private IEnumerator Teleport()
    {
        _cameraFollow._smooth = false;
        yield return new WaitForSeconds(0.5f);
        _player.transform.position = _target.position;
        yield return new WaitForSeconds(0.5f);
        _cameraFollow._smooth = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _isActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        _isActive = false;
    }

}
