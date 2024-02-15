using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup mainmenu;
    [SerializeField] private CanvasGroup options;
    [SerializeField] private CanvasGroup credits;
    [SerializeField] private CanvasGroup questions;
    [SerializeField] private CanvasGroup results;

    private static GameManager gm;

    private float _duration = 1;

    void Start()
    {
        if (gm == null)
        {
            gm = FindObjectOfType<GameManager>();
        }
    }


    public void PlayGame()
    {
        Debug.Log("play");
        StartCoroutine(FadeOut(mainmenu));
        StartCoroutine(FadeIn(questions));
    }

    public void ShowOptions()
    {
        Debug.Log("options");
        StartCoroutine(FadeOut(mainmenu));
        StartCoroutine(FadeIn(options));
    }

    public void ShowCredits()
    {
        Debug.Log("credit");
        StartCoroutine(FadeOut(mainmenu));
        StartCoroutine(FadeIn(credits));
    }

    public void Back()
    {
        StartCoroutine(FadeOut(credits));
        StartCoroutine(FadeOut(options));
        StartCoroutine(FadeIn(mainmenu));
    }

    public void GameEnd()
    {
        gm.ResetValue();
        StartCoroutine(FadeOut(results));
        StartCoroutine(FadeIn(mainmenu));
    }

    public void Quit()
    {
        Application.Quit();
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
