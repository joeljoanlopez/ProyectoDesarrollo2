using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BlackWall;
    public GameObject ThankYou;
    public GameObject Text;
    private bool _isActive;
    private bool _eventOver;
    public TextPopUpManager _text;
    public Transform _player;
    public float _timer;
    public HealthManager _healthManager;

    void Start()
    {
        _eventOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _eventOver = false;
            }
            if (_eventOver == false)
            {
                _timer += Time.deltaTime;
                if(_timer < 1.5)
                {
                    BlackWall.SetActive(true);

                    _text.ShowText("Penelope... Is that you?");
                }
               else if( _timer < 6)
                {
                    _text.ShowText("What are you... Where is Thelemachus?");

                }
                else if(_timer < 10) 
                {
                    ThankYou.SetActive(true);
                }
                else if (_timer > 14)
                {
                    _healthManager.RemoveHealth(100);
                }
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
