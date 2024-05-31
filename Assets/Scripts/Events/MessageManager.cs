using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NewBehaviourScript : MonoBehaviour
{
    public string _message;
    public float _messageTime = 3f;

    private GameObject _player;
    private TextPopUpManager _textManager;
    private Animator _animator;
    private bool _canShow;
    private float _messageTimer;
    private bool _messageShowing;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _textManager = GetComponent<TextPopUpManager>();
        _animator = GetComponent<Animator>();
        _messageTimer = _messageTime;
        _messageShowing = false;
    }

    void Update()
    {
        if (_canShow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_messageShowing)
                {
                    StartCoroutine(ShowMessage());
                    _messageShowing = true;
                }
                else
                {
                    if (_messageTimer <= 0f)
                    {
                        _animator.SetTrigger("HideMessage");
                        _messageShowing = false;
                    }
                }
            }
        }

        _messageTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
            _canShow = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == _player.tag)
            _canShow = false;
    }

    private IEnumerator ShowMessage()
    {
        _messageTimer = _messageTime;
        _animator.SetTrigger("ShowMessage");
        yield return new WaitForSeconds(0.5f);
        _textManager.ShowText(_message);
    }
}
