using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{
    void OnClick()
    {
            GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
    }
}
