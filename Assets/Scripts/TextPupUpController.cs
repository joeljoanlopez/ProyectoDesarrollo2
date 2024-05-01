using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPupUpController : MonoBehaviour
{
    public GameObject _textPopUp;
    private bool _activeText = false;
    public float _textTime = 0;
    private TextMeshProUGUI _textComponent;

    void Update()
    {
        print(_textTime);
        if (_activeText)
        {
            _textTime += Time.deltaTime;
            if (_textTime > 7)
            {
                _activeText = false;
                _textPopUp.SetActive(false);
                _textTime = 3;
            }
        }
    }

    public void ShowText(string message)
    {
        _textPopUp.SetActive(true);
        if (_textComponent == null)
        {
            _textComponent = _textPopUp.GetComponentInChildren<TextMeshProUGUI>();
        }
        else if (!_textPopUp.activeSelf) 
        {
        }

        // Reinicia el texto y el efecto de aparición
        _textComponent.text = "";
        StopCoroutine("AnimateText");

        // Comienza la animación del texto
        StartCoroutine(AnimateText(message));
    }

    private IEnumerator AnimateText(string message)
    {
        int i = 0;
        _activeText = true;

        while (i < message.Length)
        {
            _textComponent.text += message[i]; // Agrega la letra al texto

            // Espera un breve período de tiempo antes de agregar la próxima letra
            yield return new WaitForSeconds(0.05f); // Puedes ajustar este valor para controlar la velocidad de aparición

            i++;
        }
    }
}