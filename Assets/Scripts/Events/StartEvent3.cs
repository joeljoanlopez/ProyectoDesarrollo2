using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mannequin1;
    public GameObject Manneq;
    public GameObject Enemigo;
    private bool _isActive;
    private bool _eventOver;
    public Transform _player;
    public float _timer;
    private bool _stop = true;
    public Animator _animator;
    AudioManager _audioManager;


    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        _eventOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {

            if (_eventOver == true)
            {
                _animator.SetBool("Jumpscare", true);
                _eventOver = false;
            }
            
        }
        if (!_eventOver)
        {
            _timer += Time.deltaTime;
            if(_timer > 0.5)
            {
                Mannequin1.SetActive(false);
                Manneq.SetActive(false);
                Enemigo.SetActive(false);
                _stop = false;
            }
            if(_timer > 1)
            {
                Manneq.SetActive(true);
                Enemigo.SetActive(true);
            }
        } 

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _isActive = _stop;
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
