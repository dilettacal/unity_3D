using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
*  Home UI Controller
*  Switches to the next Level1 Scene
* */
public class MyPlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float jumpSpeed = 3.0f;
    public float maxSpeed = 8f;
    Rigidbody playerRigidbody;
    bool isOnFloor;
    bool pressedJump = false;

    //Animator
    Animator anim;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}



    // regelmaessig aufgerufen
    void FixedUpdate()
    {
        runController();
        jumpController();
    }


    void runController()
    {
        //controls "InputManager" - w/s or up/down keys
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Richtungsvektor - Punkt im 3D-Raum fuer die Bewegung
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); //Bewegung nur in der Ebene

        //Kraft in die Richtung geben
        //In Richtung "movement" mit Geschwindigkeit "speed"
        //Regulierung der Geschwindigkeit durch maxSpeed 
        if(playerRigidbody.velocity.magnitude > maxSpeed)
        {
            playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
        }
        else
        {
            playerRigidbody.AddForce(movement * speed);
        }

        //Gravity --> Constraints fuer Rotation sind im Panel eingesetzt worden
    }
	
    //manages Jumping
    void jumpController()
    {
        //Springen nur wenn JumpAxis > 0
        float jumpAxis = Input.GetAxis("Jump");
        if (jumpAxis > 0f)
        {
            if (isOnFloor && !pressedJump) //nur wenn Spieler auf dem Grund und nur wenn er noch nicht gesprungen ist
            {
                isOnFloor = false;
                pressedJump = false;
                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);
                //Tempo/Kraft mitgeben
                playerRigidbody.AddForce(jumpVector);
                anim.SetBool("jump", true);
            }
            
        } else
        {
            pressedJump = false;
        }

    }

    //Collision handler - if player gets into an object
    private void OnCollisionEnter(Collision collision)
    {
        //Tag is set in the Unity panel
        if(collision.gameObject.tag == "Floor")
        {
            isOnFloor = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //Collision handler - if player gets into a coin
   /* private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            GameManager.instance.AddScore(1); //player gets in touch with coin
            Destroy(collider.gameObject); //coin should be destroyed from the screen
            //if player gets in touch with the sphere --> next level

        } else if (collider.gameObject.tag == "Goal")
        {
            GameManager.instance.NextLevel();//GameManager to the next level
        }
    }*/
}
