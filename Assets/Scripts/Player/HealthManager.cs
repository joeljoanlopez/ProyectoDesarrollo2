using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float _health = 100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RemoveHealth(20);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddHealth(20);
        }
        if (_health <= 0)
        {
            RestartScene();
        }
    }

    public void AddHealth(int value)
    {
        _health += value;
    }

    public void RemoveHealth(float value)
    {
        _health -= value;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
