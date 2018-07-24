using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreLabel;
    public const int MAX_SCORE = 5;

	// Use this for initialization
	void Start () {
        updateScore();

    }

    public void updateScore()
    {
        //Updates the text of the score on Level1 screen
        scoreLabel.text = "Score: " + GameManager.instance.score + "/" + MAX_SCORE;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        updateScore();
		
	}
}
