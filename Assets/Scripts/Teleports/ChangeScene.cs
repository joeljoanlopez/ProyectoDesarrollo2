using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _currentTeleporter;
    private string _otherName = ("Player");

    public int _Scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_currentTeleporter != null)
            {
                SceneManager.LoadScene(_Scene);
            }
        }
    
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == _otherName)
        {
            
            _currentTeleporter = other.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == _otherName)
        {
            _currentTeleporter = null;
        }
    }
}
