using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StartEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mannequin1;
    public GameObject Mannequin2;
    public GameObject Text;
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
            if (_eventOver && Input.GetKeyDown(KeyCode.E))
            {
                Mannequin1.SetActive(false);
                Mannequin2.SetActive(true);
                _text.ShowText("It's closed but there seems to be have a key to another door in it");
                Text.SetActive(true);

                // Deactivate the trigger
                _eventOver = false;
            }
            else if (_eventOver == false)
            {
                _text.ShowText("It's closed and I already took the key");
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
