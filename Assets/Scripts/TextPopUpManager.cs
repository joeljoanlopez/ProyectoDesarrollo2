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
    private int _alea;

    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
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
            _alea = Random.Range(0, 5);

            _textComponent.text += message[i];

            if (_alea == 0) _audioManager.PlaySFX(_audioManager.Huh1);
            
            if (_alea == 1) _audioManager.PlaySFX(_audioManager.Huh2);

            if (_alea == 2) _audioManager.PlaySFX(_audioManager.Huh3);

            if (_alea == 3) _audioManager.PlaySFX(_audioManager.Huh4);

            if (_alea == 4) _audioManager.PlaySFX(_audioManager.Huh5);

            if (_alea == 5) _audioManager.PlaySFX(_audioManager.Huh6);

            yield return new WaitForSeconds(0.05f); 

            i++;
        }
    }
}
