using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image fadeImage; // La imagen utilizada para el fundido
    public float fadeDuration = 0.2f; // Duración del fundido en segundos

    private bool fading = false;

    // Método para iniciar el fundido
    public void StartFade()
    {
        if (!fading)
        {
            fading = true;
            StartCoroutine(FadeInOut());
        }
    }

    // Método para controlar el efecto de fundido
    IEnumerator FadeInOut()
    {
        // Fundido de entrada (fade in)
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration *2);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        // Fundido de salida (fade out)
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        fading = false;
    }
}