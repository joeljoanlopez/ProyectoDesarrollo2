using System.Collections;
using UnityEngine;

public class PlayerTeleportController : MonoBehaviour
{
    public Transform _player;
    public Transform _target;
    public bool _isClosed;
    public TextPopUpManager _text;

    private GameObject _camera;
    private CameraFollow _cameraFollow;
    private bool _isActive;
    private Animator _fadeToBlack;

    public void Start()
    {
        _isActive = false;
        _fadeToBlack = GameObject.FindWithTag("Curtain").GetComponent<Animator>();
        _camera = GameObject.FindWithTag("MainCamera");
        _cameraFollow = _camera.GetComponent<CameraFollow>();
    }
    private void Update()
    {
        if(_isClosed == true && Input.GetKeyDown(KeyCode.E) && _isActive)
        {
            _text.ShowText("It's closed");
        }
        else if (_isActive && Input.GetKeyDown(KeyCode.E))
        {
            _fadeToBlack.SetTrigger("FadeStart");
            StartCoroutine(Teleport());
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
