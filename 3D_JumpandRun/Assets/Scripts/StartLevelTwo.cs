using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelTwo : MonoBehaviour
{
    // Start is called before the first frame update


    void OnClick()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadNextLevel();
    }
}
