using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent5 : MonoBehaviour
{
    // Start is called before the first frame update

    private bool _isActive;
    private bool _eventOver;
    public TextPopUpManager _text;
    public Transform _player;
    public float _timer;
    private bool _timerStart;
    public float _messageNumber = 0;
    public GameObject _e;
    public GameObject _box;
    void Start()
    {
        _eventOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_eventOver)
        {
            if (_isActive && Input.GetKey(KeyCode.E) && _messageNumber == 0)
            {
                _text.ShowText("Penelope Telemachus...");
                _timerStart = true;
                _messageNumber += 1;
            }
            if(_timer > 3 && _messageNumber == 1) 
            {
                _text.ShowText("Why do they Sound familiar...?");
                _messageNumber += 1;

            }
            if (_timer > 7 && _messageNumber == 2)
            {
                _text.ShowText("I think they are the names of my wife and son...");
                _messageNumber += 1;

            }
            if (_timer > 11 && _messageNumber == 3)
            {
                _text.ShowText("Wait for me, I will get out of this place");
                _eventOver = false;
                _messageNumber += 1;
            }
        }
        if (_timerStart)
        {
            _timer += Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _isActive = true;
            _e.SetActive(true);
            _box.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _isActive = false;
            _e.SetActive(false);
            _box.SetActive(false);



        }
    }
}
