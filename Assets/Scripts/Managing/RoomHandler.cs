using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    private Collider2D _player;
    public GameObject _levelParent;

    private GameObject[] _levels;
    private int _levelNumber;
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        _levelNumber = _levelParent.transform.childCount;
        _levels = new GameObject[_levelNumber];
        _player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();

        for (int i = 0; i < _levelNumber; i++)
        {
            _levels[i] = _levelParent.transform.GetChild(i).gameObject;
        }
    }

    public int PlayerLevel()
    {
        return GetLevelNumber(_player);
    }

    public int GetLevelNumber(Collider2D collider)
    {
        bool _found = false;
        int _currentLevel = 0;

        while (!_found && _currentLevel < _levels.Length)
        {
            Collider2D[] _colliders = _levels[_currentLevel].GetComponentsInChildren<Collider2D>();
            for (int i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i].IsTouching(collider))
                    _found = true;
            }

            if (!_found) _currentLevel++;
        }
        return _currentLevel;
    }

}
