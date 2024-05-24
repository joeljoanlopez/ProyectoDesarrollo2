using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mannequin1;
    public GameObject Mannequin2;
    public GameObject Manneq;
    public GameObject Enemigo;
    private bool _isActive;
    private bool _eventOver;
    public TextPopUpManager _text;
    public Transform _player;



    void Start()
    {
        _eventOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            if (_eventOver == false && Input.GetKeyDown(KeyCode.E))
            {
                _text.ShowText("It's closed");
            }
            else if (_eventOver && Input.GetKeyDown(KeyCode.E))
            {
                Mannequin1.SetActive(false);
                Mannequin2.SetActive(true);
                _text.ShowText("It's closed but something else opened");
                Manneq.SetActive(false);
                Enemigo.SetActive(true);

                _eventOver = false;
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
