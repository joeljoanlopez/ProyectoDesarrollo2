using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThankYou;
    public GameObject Text;
    private bool _isActive;
    private bool _eventOver;
    public TextPopUpManager _text;
    public Transform _player;
    public float _timer;
    public HealthManager _healthManager;
    public Animator _wife;
    public MovementController _movementController;

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
                _timer += Time.deltaTime;
                if(_timer < 1.5)
                {
                    _movementController._canMove = false;
                    _text.ShowText("Penelope... Is that you?");
                    _wife.SetInteger("State", 1);
                }
               else if( _timer < 4)
                {
                    _text.ShowText("What are you... Where is Thelemachus?");
                    _wife.SetInteger("State", 2);

                }
                else if(_timer < 5) 
                {
                    _wife.SetInteger("State", 3);
                }
                else if (_timer < 8)
                {
                    _wife.SetInteger("State", 4);
                    
                }
                else if (_timer < 8.4)
                {
                    _wife.SetInteger("State", 5);

                }
                else if (_timer < 10)
                {
                    SceneManager.LoadScene(3);
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
