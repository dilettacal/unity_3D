using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Coin in unity: isTrigger is activated. An handler for this triggering function should be implemented in the PlayerController.
 * The player should get points, if he gets in touch with coins
**/
public class CoinController : MonoBehaviour {

    public float rotationSpeed = 150f; // Rotation speed of the object (grads)
	
	
	// Update is called once per frame
	void Update () {
        float angle = rotationSpeed * Time.deltaTime; //time from last call of this function
        transform.Rotate(Vector3.up * angle, Space.World); //Coin rotates direction up with angle angle in the actual world
		
	}
}
