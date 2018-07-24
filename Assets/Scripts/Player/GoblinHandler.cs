using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinHandler : MonoBehaviour {

    //Rigidbody playerRigidbody;
    //bool isOnFloor;
    //Animator anim;

    // Use this for initialization
    /*void Start () {
        //playerRigidbody = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Collision handler - if player gets into an object
    private void OnCollisionEnter(Collision collision)
    {
        //Tag is set in the Unity panel
        if (collision.gameObject.tag == "Floor")
        {
            //isOnFloor = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //Collision handler - if player gets into a coin
    /*private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            GameManager.instance.AddScore(1); //player gets in touch with coin
            Destroy(collider.gameObject); //coin should be destroyed from the screen
            //if player gets in touch with the sphere --> next level

        }
        else if (collider.gameObject.tag == "Goal")
        {
            GameManager.instance.NextLevel();//GameManager to the next level
        }
    }*/
}
