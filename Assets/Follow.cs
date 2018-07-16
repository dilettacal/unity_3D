using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject target; //Target of the camera follow
    private Vector3 distance; //between camera and object

	// Use this for initialization
	void Start () {
        distance = transform.position - target.transform.position; //Difference camera and target
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = target.transform.position + distance;
	}
}
