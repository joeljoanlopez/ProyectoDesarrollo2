using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    // Start is called before the first frame update
    private float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime; 
        if (_timer >= 28)
        {
            SceneManager.LoadScene(2);
        }

    }
}
