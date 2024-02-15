using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBehaviour : MonoBehaviour {

    public int timeStart;
    public Text textBox;
    GameManager gm;


    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        textBox.text =  gm.GetActiveScene().ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
