using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Interactable;

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Deathzone"))
        {
            Destroy(gameObject, 0.0f);
            Vector3 position = new Vector3(2, 7, 3);
            GameObject cube = Instantiate(_Interactable, position, Quaternion.identity);
        }
    }

}
