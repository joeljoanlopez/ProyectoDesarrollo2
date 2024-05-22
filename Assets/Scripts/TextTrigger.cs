using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public TextPopUpManager _text;
    public string _shownText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the message
            _text.ShowText(_shownText);

            // Deactivate the trigger
            gameObject.SetActive(false);
        }
    }
}
