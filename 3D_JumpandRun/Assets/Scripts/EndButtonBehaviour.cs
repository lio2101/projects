using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonBehaviour : MonoBehaviour
{   
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().CloseGame();
    }   
}
