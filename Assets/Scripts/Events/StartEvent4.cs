using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent4 : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerTeleportController _teleport;
    public GameObject Text;
    private bool _isActive;
    private bool _eventOver;
    public TextPopUpManager _text;
    public Transform _player;
    public PlayerTeleportController _playerTeleportController;


    void Start()
    {
        _eventOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            if (_eventOver == false)
            {
                _teleport._isClosed = false;
                _playerTeleportController._isClosed = false;
                _text.ShowText("There's a key here");
                _eventOver = true;
            }
            else if (_eventOver)
            {

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _isActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _isActive = false;
        }
    }
}
