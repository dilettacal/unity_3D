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
        //coinsGenerate(6);
	}

    void coinsGenerate(int anzahl)
    {
        //MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        //Resolution terrainSize = gameObject.get

        /*        float minX = renderer.bounds.min.x;
                float maxX = renderer.bounds.max.x;
                float minZ = renderer.bounds.min.z;
                float maxZ = renderer.bounds.max.x;
                
                float newX = Random.Range(50, 750);
                float newZ = Random.Range(50, 750);
                float newY = gameObject.transform.position.y+7;

                int i = 0;
                while(i < anzahl)
                {
                    GameObject coin = GameObject.FindGameObjectWithTag("Coin");
                    coin.transform.position = new Vector3(newX, newY, newZ);
                }
                
        Debug.Log("Anzahl ist: "+anzahl); */
        
    }
}
