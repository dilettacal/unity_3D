using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMove : MonoBehaviour {

	public float speed = 0.1f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRB;          // Reference to the player's rigidbody.
    int floor;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    // Goblin part
    //private Animator anim;
    private CharacterController controller;
    //public float speed = 6.0f;
    public float runSpeed = 3.7f;
    public float turnSpeed = 60.0f;
    public float gravity = 20.0f;
    //private bool battle_state;
    private Vector3 moveDirection = Vector3.zero;

    Quaternion originRo;
    float angle;
    float mouseX;
    float mouseSens = 5f;
    float stopFactor = 5;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floor = LayerMask.GetMask("Floor");

        // Set up references.
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();

        originRo = transform.rotation;

        controller = GetComponent<CharacterController>();
    }


    void FixedUpdate ()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        //Move(h, v);

        // Turn the player to face the mouse cursor.
        //Turning();

        // Animate the player.
        //Animating(h, v);

        
        mouseX += Input.GetAxis("Mouse X") * mouseSens;
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        transform.rotation = originRo * rotationY;
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward / stopFactor;
        } */

        Moving(h, v);
        
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward;
        }

        // Move the player to it's current position plus the movement.
        playerRB.MovePosition(transform.position + movement);
    }

    void Turning ()
    {
        //float rotation = 0;
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        if (Input.GetMouseButton(0))
        {
            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floor))
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = (floorHit.point - transform.position);

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse / stopFactor);

                // Set the player's rotation to this new rotation.
                playerRB.MoveRotation(newRotation);
                //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
        }

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

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);

        if (Input.GetKeyDown("space"))
        {
            bool jumping = h != 0f || v != 0f;
            anim.SetBool("IsJumping", jumping);
        }
        else
        {
            //anim.SetBool("IsWalking", false);
            anim.SetBool("IsJumping", false);
        }
    }
    
    void Moving(float h, float v)
    {
        //anim.SetInteger("battle", 0);

        //float hor = Input.GetAxis("Vertical");
        // walk with up
        if (Input.GetKey("up"))
        //if (hor != 0)
        {
            anim.SetInteger("moving", 1);//walk
            runSpeed = 1.0f;
        } else
        {
            anim.SetInteger("moving", 0);
        }

        // run with Shift
        if (Input.GetKey("left shift"))
        {
            anim.SetInteger("moving", 2);//run
            runSpeed = 2.6f;         
        }
        else
        {
            anim.SetInteger("moving", 0);
        }


        if (Input.GetKeyDown("space")) //jump
        {
            anim.SetInteger("moving", 7);
        }

        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed * runSpeed;

        }
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}

