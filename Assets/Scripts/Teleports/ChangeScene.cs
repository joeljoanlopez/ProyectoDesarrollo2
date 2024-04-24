using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int _scene;
    public Transform _player;
    private GameObject _currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_currentTeleporter != null)
                SceneManager.LoadScene(_scene);
        }
    
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
            _currentTeleporter = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == _player.tag)
            _currentTeleporter = null;
    }
}
