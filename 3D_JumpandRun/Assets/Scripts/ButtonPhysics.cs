using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPhysics : MonoBehaviour
{

    private Color green = new Color(0, 100, 0);
    Renderer renderer;
    public UnityEvent onPressed;


    void Awake()
    {
        renderer = GameObject.FindGameObjectWithTag("Button").GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate(){
        Debug.Log("button1");
        renderer.material.SetColor("_Color", Color.green);
        onPressed.Invoke();

    }
}