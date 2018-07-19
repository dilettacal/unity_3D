using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour {

    public Text score;
    public Text highscore;

	// Use this for initialization
	void Start () {
        score.text = GameManager.instance.score.ToString();
        highscore.text = GameManager.instance.highscore.ToString();
    }
	
	public void RestartGame()
    {
        GameManager.instance.Reset();
    }
}
