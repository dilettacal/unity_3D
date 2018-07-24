using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreLabel;
    public const int MAX_SCORE = 5;
    public static ScoreManager instance = null;

    void Awake()
    {

        if (instance == null)
        {
            instance = this; //reference to this game manager
            //Switching among scenes --> only 1 game manager!!
        }
        else if (instance != this)
        {
            //destroy
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); //when a new scene is loaded, game manager should be transferred to the new scene

    }

    // Use this for initialization
    void Start () {
       UpdateScore();

    }

    public void UpdateScore()
    {
        //Updates the text of the score on Level1 screen
        scoreLabel.text = "Score: " + GameManager.instance.score + "/" + MAX_SCORE;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateScore();
		
	}
}
