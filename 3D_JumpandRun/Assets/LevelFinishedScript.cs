using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishedScript : MonoBehaviour
{
    public GameObject LevelFinishedPanel;

    void Start()
    {
        LevelFinishedPanel.SetActive(false);
    }

    public void Activate()
    {
        Debug.Log("activate");
        LevelFinishedPanel.SetActive(true);
    }
}
