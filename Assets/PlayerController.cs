using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpSpeed = 3f;
    Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
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
        playerRigidbody.AddForce(movement*speed);

        //Gravity --> Constraints fuer Rotation sind im Panel eingesetzt worden
    }
	
	// regelmaessig aufgerufen
	void FixedUpdate () {
        runController();
	}
}
