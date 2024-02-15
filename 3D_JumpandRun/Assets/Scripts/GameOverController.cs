using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    public void Activate()
    {
        GameOverPanel.SetActive(true);
    }

}
