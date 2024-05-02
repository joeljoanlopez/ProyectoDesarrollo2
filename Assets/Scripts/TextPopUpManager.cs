using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUpManager : MonoBehaviour
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
            if (_textTime > 3)
            {
                _activeText = false;
                _textPopUp.SetActive(false);
                _textTime = 0;
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

        _textComponent.text = "";
        StopCoroutine("AnimateText");

        StartCoroutine(AnimateText(message));
    }

    private IEnumerator AnimateText(string message)
    {
        int i = 0;
        _activeText = true;

        while (i < message.Length)
        {
            _textComponent.text += message[i]; 

            yield return new WaitForSeconds(0.05f); 

            i++;
        }
    }
}
