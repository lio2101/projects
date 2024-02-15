using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformMovement : MonoBehaviour
{
    private bool transRight = true;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x >= 3)
        {
            transRight = false;
        }

        if (transform.position.x <= -3)
        {
            transRight = true;
        }

    }
}
