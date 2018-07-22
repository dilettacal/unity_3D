using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    Animator anim;

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        float rotation = 0;

        if(Input.GetKey("space"))
        {
            anim.SetBool("IsWalking", true);
            transform.Translate(0, 0, 0.3f);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ( Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                this.transform.LookAt(hit.point);
                rotation = Input.mousePosition.x - Screen.width / 2;
            }
        }

        if(rotation != 0)
        {
            anim.SetBool("goStraight", false);
            if(rotation < 0)
            {
                anim.SetBool("turnLeft", true);
                anim.SetBool("turnRight", false);
            }
            else
            {
                anim.SetBool("turnLeft", false);
                anim.SetBool("turnRight", true);
            }
        }
        else
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("turnLeft", false);
            anim.SetBool("turnRight", false);
        }
    }
}
