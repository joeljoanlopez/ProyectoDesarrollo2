using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUpManager : MonoBehaviour
{

    public GameObject _textPopUp;
    public bool _isTimed = true;

    private bool _activeText = false;
    private float _textTime = 0;
    private TextMeshProUGUI _textComponent;
    private int _alea;
    private bool _canTalk;

    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _canTalk = true;
    }
    void Update()
    {
        if (_activeText)
        {
            _textTime += Time.deltaTime;
            if (_isTimed && _textTime > 3)
            {
                _activeText = false;
                _textPopUp.SetActive(false);
                _textTime = 0;
            }
        }

        _canTalk = !_activeText;
    }

    public void ShowText(string message)
    {
        if (_textComponent == null)
            _textComponent = _textPopUp.GetComponentInChildren<TextMeshProUGUI>();
        _textPopUp.SetActive(true);
        if (_canTalk)
        {
            StartCoroutine(AnimateText(message));
        }
    }

    private IEnumerator AnimateText(string message)
    {
        int i = 0;
        _textComponent.text = "";
        _textTime = 0;
        _activeText = true;
        while (i < message.Length)
        {
            _textComponent.text += message[i];

            _alea = Random.Range(0, 5);

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
