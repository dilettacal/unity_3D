using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//Steuert den Lokalen Player (also im lokalen Fenster)
public class SetupLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {

        if (isLocalPlayer)
        {
            //this Goblin wird vom aktuellen Benutzer verwendet
            GetComponent<GoblinMovement>().enabled = true;
            CameraFollow360.player = this.gameObject.transform;
        }
        else
        {
            //this Goblin wird von einem anderen Benutzer verwendet
            GetComponent<GoblinMovement>().enabled = false;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
