using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTeleportController : MonoBehaviour
{
    // // Start is called before the first frame update
    // private GameObject _currentTeleporter;
    // private FadeToBlack _fadeToBlack;
    // void Start()
    // {
    //     _fadeToBlack = FindObjectOfType<FadeToBlack>();

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Return) ) 
    //     {
    //         if(_currentTeleporter != null) 
    //         {
    //             _fadeToBlack.StartFade();

    //             transform.position = _currentTeleporter.GetComponent<DoorController>().GetDestination().position;
    //         }
    //     }
    // }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.GetComponent<DoorController>() != null)
    //     {
    //         _currentTeleporter = other.gameObject;
    //     }

    // }
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.GetComponent<DoorController>() != null)
    //     {
    //         _currentTeleporter = null;

    //     }

    // }

    public Transform _player;
    public Transform _target;
    private bool _isActive;

    public void Start()
    {
        _isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == _player.name)
        {
            _isActive = true;
        }
    }

    public void OnTriggerExit(Collider2D other){
        _isActive = false;
    }

    private void Update(){
        if (_isActive && Input.GetKeyDown(KeyCode.E)){
            _player.transform.position = _target.position;
        }
    }

}
