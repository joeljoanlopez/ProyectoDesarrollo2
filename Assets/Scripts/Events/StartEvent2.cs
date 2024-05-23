using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StartEvent2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mannequin1;
    public GameObject Mannequin2;
    public GameObject Manneq;
    public GameObject Enemigo;
    private bool _isActive;
    private bool _eventOver;
    public Transform _player;
    public float timer;



    void Start()
    {
        _eventOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {

 
                Mannequin1.SetActive(false);
                Mannequin2.SetActive(true);
                Manneq.SetActive(false);
                Enemigo.SetActive(true);

                _eventOver = false;
            
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
