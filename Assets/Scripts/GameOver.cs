using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private string SCENE_NAME = "DiScene";
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -5.0f) //diamo tempo al giocatore di capire che sta cadendo
        {
            Application.LoadLevel(SCENE_NAME);
        }
	}
}
