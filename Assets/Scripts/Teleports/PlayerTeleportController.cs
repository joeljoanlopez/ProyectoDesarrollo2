using System.Collections;
using UnityEngine;

public class PlayerTeleportController : MonoBehaviour
{
    public Transform _player;
    public Transform _target;
    private bool _isActive;
    private Animator _fadeToBlack;

    public void Start()
    {
        _isActive = false;
        _fadeToBlack = GameObject.FindWithTag("Curtain").GetComponent<Animator>();

    }
    private void Update()
    {
        if (_isActive && Input.GetKeyDown(KeyCode.E))
        {
            _fadeToBlack.SetTrigger("FadeStart");
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        _player.transform.position = _target.position;
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
