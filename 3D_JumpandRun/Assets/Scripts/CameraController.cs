using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public InputAction zoom; //??
    GameObject cam;

    void Awake(){

    }

    void Start()
    {
     cam = GameObject.Find("Main Camera"); //??
    }

    void OnEnable(){
        zoom.Enable();
    }
    void OnDisable(){
        zoom.Disable();
    }    


    // Update is called once per frame
    void Update()
    {
     if(Input.GetAxis("Mouse ScrollWheel") > 0f){
        Camera.main.fieldOfView--;
     }
     if(Input.GetAxis("Mouse ScrollWheel") < 0f){
        Camera.main.fieldOfView++;
     }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(2, 5, -2);

   

    }
}
