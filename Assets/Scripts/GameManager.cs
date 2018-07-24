using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //At game start there should be an instance of game manager
    public int score = 0;

    public int highscore = 0;

    //Switching among game levels
    //max level firstly=2
    public int level = 1;
    private int maxLevel = 2;

	void Awake () {

        if(instance == null)
        {
            instance = this; //reference to this game manager
            //Switching among scenes --> only 1 game manager!!
        } else if(instance != this)
        {
            //destroy
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); //when a new scene is loaded, game manager should be transferred to the new scene
		
	}
	
    private void Start()
    {
       highscore= PlayerPrefs.GetInt("highscore");
    }

    //Nicht verwendet
	public void RpcAddScore(int newScoreValue)
    {
        //score += newScoreValue; //scores higher
        if(score > highscore)
        {
            //update highscore
            highscore = score;
            //save permanently in the game
            PlayerPrefs.SetInt("highscore", highscore); 
        }
    }

    public void AddScore(int newScore)
    {
       /* if (!isServer)
        {
            return;
        }*/
        score += newScore;
        if (score > highscore)
        {
            //update highscore
            highscore = score;
            //save permanently in the game
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highscore;
    }

    public void NextLevel()
    {
        if(level < maxLevel)
        {
            level++; //to the new level
            SceneManager.LoadScene("Level" + level);
        } else
        {
            //level = 1; //come back to the first level
            SceneManager.LoadScene("WinScene");
        }
        //SceneManager.LoadScene("Level" + level); //Levels should have this format "Level1", "Level2"...
    }

    public void Reset()
    {
        score = 0;
        level = 1;
        SceneManager.LoadScene("Level" + level); //Loads "Level1"
    }
}
