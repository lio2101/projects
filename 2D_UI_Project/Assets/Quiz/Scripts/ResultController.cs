using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class ResultController : MonoBehaviour
{

    [SerializeField] private Image img;
    [SerializeField] private TMP_Text txt;

    [SerializeField] private Sprite snakeImg;
    [SerializeField] private Sprite catImg;
    [SerializeField] private Sprite parrotImg;
    [SerializeField] private Sprite dogImg;

    private static GameManager gm;

    void Start()
    {
        img.GetComponent<SpriteRenderer>();

        if (gm == null)
        {
            gm = FindObjectOfType<GameManager>();
        }
    }

    public void ShowResult()
    {
        string result = gm.CalcResult();
        txt.text = "a " + result;
        
        if (result == "Snake") { img.sprite = snakeImg; }
        if (result == "Cat") { img.sprite =  catImg; }
        if (result == "Parrot") { img.sprite = parrotImg; }
        if (result == "Dog") { img.sprite = dogImg; }
    }
        
}
