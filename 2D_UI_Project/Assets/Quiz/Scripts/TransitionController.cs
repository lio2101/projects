using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private CanvasGroup thisCanvas;
    [SerializeField] private CanvasGroup nextCanvas;
    private float _duration = 1;

    
    public void OnButtonClicked()
    {
        Debug.Log("continue");
        StartCoroutine(FadeOut(thisCanvas));
        StartCoroutine(FadeIn(nextCanvas));
    }

    IEnumerator FadeOut(CanvasGroup menu)
    {
        Debug.Log("fadeout");
        float startTime = Time.time;
        float startAlpha = menu.alpha;
        float targetAlpha = 0;

        while (startTime + _duration > Time.time)
        {
            float t = Mathf.Clamp01((Time.time - startTime) / _duration);
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            menu.alpha = alpha;
            yield return null;
        }
        menu.interactable = false;
        menu.blocksRaycasts = false;
        yield return null;
    }

    IEnumerator FadeIn(CanvasGroup menu)
    {
        Debug.Log("fadein");
        float startTime = Time.time;
        float startAlpha = menu.alpha;
        float targetAlpha = 1;

        while (startTime + _duration > Time.time)
        {
            float t = Mathf.Clamp01((Time.time - startTime) / _duration);
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            menu.alpha = alpha;
            yield return null;
        }
        menu.interactable = true;
        menu.blocksRaycasts = true;
    }
}
