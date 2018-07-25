using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Klasse zur Steuerung der Punkte - SinglePlayer
public class ScoreManager : MonoBehaviour {

    public Text scoreLabel;
    public const int MAX_SCORE = 5;

	// Use this for initialization
	void Start () {
        updateScore();

    }

    public void updateScore()
    {
        scoreLabel.text = "Score: " + GameManager.instance.score.ToString() + "/" + MAX_SCORE;

        //Das wird in der Console angezeigt aber Label wird nicht aktualisiert
        Debug.Log("Label: " + scoreLabel.text);
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        updateScore();
		
	}
}
