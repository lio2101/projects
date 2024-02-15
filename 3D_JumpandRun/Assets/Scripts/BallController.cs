using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    Renderer renderer;
    GameManager gm;
    GameOverController go;
    LevelFinishedScript tw;
    GameObject LaserBeam;
    ShieldBehaviour shield;
    ButtonPhysics button;

    public InputAction move;
    public InputAction jump;
    public float jumpForce = 3.0f;
    public float acceleration = 2.0f;
    public float maxSpeed = 1f;
    public bool isGrounded;
    public bool isOrange;
    public bool isBlue;

    // Hier Attribute Initialisieren
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        go = GameObject.FindGameObjectWithTag("GameOverTag").GetComponent<GameOverController>();
        tw = GameObject.FindGameObjectWithTag("LevelFinished").GetComponent<LevelFinishedScript>();
        LaserBeam = GameObject.FindGameObjectWithTag("LaserBeam").GetComponent<GameObject>();
        //shield = GameObject.FindGameObjectWithTag("Shield").GetComponent<ShieldBehaviour>();
        button = GameObject.Find("Button").GetComponent<ButtonPhysics>();
    }

        void OnEnable()
        {
            move.Enable();
            jump.Enable();
        }

        void OnDisable()
        {
            move.Disable();
            jump.Disable();
        }

        // Start is called before the first frame update Hier find() benutzen
        void Start()
        {
            Debug.Log("POG");
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("OrangePotion"))
            {
                Debug.Log("orangepotion");
                renderer.material = collider.gameObject.GetComponent<Renderer>().material;
                Destroy(collider.gameObject, 0.1f);
                if (isBlue)
                {
                    isBlue = false;
                }
                isOrange = true;
            }
            if (collider.gameObject.CompareTag("BluePotion"))
            {
                Debug.Log("bluepotion");
                renderer.material = collider.gameObject.GetComponent<Renderer>().material;
                Destroy(collider.gameObject, 0.1f);
                if (isOrange)
                {
                    isOrange = false;
                }
                isBlue = true;
            }
            if (collider.gameObject.CompareTag("ShieldPotion"))
            {
                Debug.Log("shieldpotion");
                Destroy(collider.gameObject, 0.1f);
                //shield.Activate();
            }

            if (collider.gameObject.CompareTag("BlueWall"))
            {
                if (isBlue)
                {
                    Debug.Log("same color");
                    Destroy(collider.gameObject.GetComponent<BoxCollider>(), 0.0f);
                }
                else
                {
                    if (gm.GetPlayerHealth() == 1)
                    {
                        go.Activate();
                    }
                    gm.Damage();
                }
            }
            if (collider.gameObject.CompareTag("OrangeWall"))
            {
                if (isOrange)
                {
                    Debug.Log("same color");
                    Destroy(collider.gameObject.GetComponent<BoxCollider>(), 0.0f);
                }
                else
                {
                    if (gm.GetPlayerHealth() == 1)
                    {
                        go.Activate();
                    }
                    gm.Damage();
                }
            }
            if (collider.gameObject.CompareTag("LaserBeam"))
            {
                Debug.Log("Laserbeam");
                if (gm.GetPlayerHealth() == 1)
                {
                    go.Activate();
                }
                gm.Damage();
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Deathzone"))
            {
                Debug.Log("Leider verloren!");

                go.Activate();
                //gm.Death();
            }

            if (collision.gameObject.CompareTag("LevelFinished"))
            {
                Debug.Log("Ziel erreicht!");
                tw.Activate();
            }
            if (collision.gameObject.CompareTag("FinishGame"))
            {
                Debug.Log("Ziel erreicht!");
                gm.Win();
            }
            if (collision.gameObject.CompareTag("Projectile"))
            {
                Debug.Log("Kugel getroffen!");
                if (gm.GetPlayerHealth() == 1)
                {
                    go.Activate();
                }
                gm.Damage();
            }
            if (collision.gameObject.CompareTag("Button"))
            {
                Debug.Log("button");
                button.Activate();
            }
        }

        void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                acceleration = 2.0f;
                maxSpeed = 4f;
                isGrounded = true;
            }
            if (collider.gameObject.layer == LayerMask.NameToLayer("Ice"))
            {
                acceleration = 0.5f;
                maxSpeed = 3f;
            }
        }

        void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //WASD
            Vector2 movement = move.ReadValue<Vector2>();
            rb.AddForce(movement.x * acceleration, 0, movement.y * acceleration);

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
            }

            //Jump
            float jumping = jump.ReadValue<float>();
            if (isGrounded && jumping != 0)
            {
                acceleration = 5;
                maxSpeed = 4;
                rb.AddForce(0, jumping * jumpForce, 0, ForceMode.Impulse);
                Debug.Log("jump");
            }
            isGrounded = false;
        }
    }

