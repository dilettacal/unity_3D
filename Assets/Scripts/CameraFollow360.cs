using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow360 : MonoBehaviour
{

    static public Transform player; //access to all player connected to the game
    public float distance = 50;
    public float height = 70;
    public Vector3 lookOffset = new Vector3(0, 10, 0);
    float cameraSpeed = 80;
    float rotSpeed = 15;

    void FixedUpdate()
    {
        if (player)
        {
            Vector3 lookPosition = player.position + lookOffset;
            Vector3 relativePosition = lookPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePosition);

            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * rotSpeed * 0.1f);
            Vector3 targetPos = player.transform.position + player.transform.up * height - player.transform.forward * distance;
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * cameraSpeed * 0.1f);
        }
    }
}
