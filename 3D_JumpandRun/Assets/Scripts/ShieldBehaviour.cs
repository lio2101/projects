using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{

    public GameObject shield;
    
    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Projektil abgewehrt");
            Destroy(shield);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        shield.SetActive(true);
    }
}
