using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float distance; //Beweungsdistanz
    public bool moveUp = false;
    public bool moveSide = true; //rechts und links moeglich

    Vector3 startingPos;

    Transform trans; //Speichert die Position von Feind


    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>(); //initialisiert die Position
        startingPos = trans.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (moveUp)
        {
            //ping pong Funktion bewegt nach oben und nach unten
            trans.position = new Vector3(startingPos.x, startingPos.y + Mathf.PingPong(Time.time, distance/3), startingPos.z);
        }
        if (moveSide)
        {
            //ping pong Funktion bewegt hin und her
            trans.position = new Vector3(startingPos.x + Mathf.PingPong(Time.time, distance), startingPos.y, startingPos.z);
        }
        if (moveSide && moveUp)
        {
            trans.position = new Vector3(startingPos.x + Mathf.PingPong(Time.time, distance/2), startingPos.y + Mathf.PingPong(Time.time, distance), startingPos.z);
        }

    }
}
