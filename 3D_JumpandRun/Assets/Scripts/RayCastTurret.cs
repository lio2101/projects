using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTurret : MonoBehaviour
{

    public Transform rayStart;
    public Transform playerTransform;
    public Vector3 playerPosition;

    public GameObject projectile;
     
    float firerate = 0.8f;
    float firerateDelta;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        playerPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

        //Turm rotieren lassen
        Vector3 playerDirection = playerPosition - transform.position;
        Vector3 LookingDirection = Vector3.RotateTowards(transform.forward, playerDirection, 5f, 0f);
        transform.rotation = Quaternion.LookRotation(LookingDirection);

        firerateDelta -= Time.deltaTime;
        if(firerateDelta <= 0) {
            fire();
            firerateDelta = firerate;
        }

        if (Physics.Raycast(rayStart.transform.position, rayStart.transform.forward, out hit, 100f))
        {
            Debug.Log("Ich schieße auf Objekt:" + hit.transform.name);
        } else {
            Debug.Log("Nothing got hit!");
        }

        Debug.DrawRay(rayStart.transform.position, rayStart.transform.forward, Color.blue);
        
    }

    public void fire() {
        GameObject projectileInstance = Instantiate(projectile, rayStart.position, transform.rotation);
        Destroy(projectileInstance, 20f);
    }
}
