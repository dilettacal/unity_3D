using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject; //player
        var score = hit.GetComponent<Score>();
        if(score != null)
        {
            score.AddNewScore(1);
        }
        Destroy(gameObject);
    }
}
