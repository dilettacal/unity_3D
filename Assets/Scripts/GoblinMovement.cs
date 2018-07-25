using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinMovement : MonoBehaviour
{

    //public float speed;            // The speed that the player will move at.
    public float walkSpeed = 0.3f;
    public float runSpeed = 0.5f;

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 500f;          // The length of the ray from the camera into the scene.
                                        //bool isOnFloor;
                                        // Goblin part
                                        //private Animator anim;
                                        //private CharacterController controller;

    public float turnSpeed = 60.0f;
    //public float gravity = 20.0f;

    Quaternion originRotation;
    float angle;
    float mouseX;
    float mouseSens = 5f;
    //public float stopFactor;

    public float jumpHeight;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        originRotation = transform.rotation;
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float jump = Input.GetAxisRaw("Jump");
        float run = Input.GetAxisRaw("Sprint");

        // Move the player around the scene.
        //Move(h, 0, v);
        //Move(h, 0, run);


        // Turn the player to face the mouse cursor.
        Turning();

        // Animate the player.
        Animating(h, v, jump, run, false);

        /*if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime, Space.World);
        } */

        /*
        mouseX += Input.GetAxis("Mouse X") * mouseSens;
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        transform.rotation = originRotation * rotationY;
        */
        if (v != 0)
        {
            //transform.position += transform.forward;
            Move(h, 0f, v, walkSpeed);
        }
        else if (run != 0)
        {
            Move(h, 0f, run, runSpeed);
        }

    }

    void Move(float h, float height, float v, float speed)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, height, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        /* if (Input.GetKey(KeyCode.W))
         {
             transform.position += transform.forward;
         } */

        // Move the player to it's current position plus the movement.
        playerRigidbody.position += (transform.forward * speed);
        //playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        //float rotation = 0;
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        //if (Input.GetMouseButton(0))
        //{
        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = (floorHit.point - transform.position);

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        //}

        /* if (Input.GetMouseButton(0))
         {
             if (Physics.Raycast(camRay, out floorHit, 100))
             {
                 Debug.DrawLine(camRay.origin, floorHit.point);
                 this.transform.LookAt(floorHit.point);
                 rotation = Input.mousePosition.x - Screen.width / 2;
             }
         } */
    }

    void Animating(float h, float v, float jump, float run, bool die)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);

        if (run != 0)
        {
            anim.SetInteger("move", 2);//run
            //runSpeed = 2.6f;
        }
        else
        {
            anim.SetInteger("move", 0);
        }


        if (jump != 0) //jump
        {
            anim.SetInteger("move", 7);
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime, Space.World);
        }

        if (die)
        {
            anim.SetInteger("move", 5);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Tag is set in the Unity panel
        //Tag is set in the Unity panel
        if (collision.gameObject.tag == "Floor")
        {
            //isOnFloor = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            anim.SetInteger("move", 5);
            Animating(0, 0, 0, 0, true);
            anim.SetTrigger("Die");
        }
        else if (collision.gameObject.tag == "Mushroom")
        {
            anim.SetInteger("move", 5);
            Animating(0, 0, 0, 0, true);
            anim.SetTrigger("Die");
        }
        else
        {
            anim.SetInteger("move", 0);
        }
    }

    //Collision handler - if player gets into a coin
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            GameManager.instance.AddScore(1); //player gets in touch with coin
            Debug.Log(GameManager.instance.score);
            Destroy(collider.gameObject); //coin should be destroyed from the screen
            //if player gets in touch with the sphere --> next level

        }
        else if (collider.gameObject.tag == "Goal")
        {
            GameManager.instance.NextLevel();//GameManager to the next level
        }
    }
}

