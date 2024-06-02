using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Rat : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _Scared;
    public GameObject _player;
    public Animator _animator;
    void Start()
    {
        _Scared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_Scared == true)
        {
            _animator.SetBool("IsScard", true);
        }
        else if( _Scared == false) 
        { 
        
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
        {
            _Scared = true;
        }
    }

}
