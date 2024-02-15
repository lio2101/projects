using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    GameManager gm;

    private int maxPlayerHealth;
    private int playerHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update(){

        maxPlayerHealth = gm.GetMaxPlayerHealth();
        playerHealth = gm.GetPlayerHealth();
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth){ hearts[i].sprite = fullHeart; }
            else{ hearts[i].sprite = emptyHeart; }

            if (i < maxPlayerHealth-1){ hearts[i].enabled = true; }
            if (i > maxPlayerHealth-1){ hearts[i].enabled = false; }
        }
    }
}

