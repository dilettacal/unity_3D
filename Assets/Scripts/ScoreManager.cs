using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreManager : NetworkBehaviour {

    public Text scoreLabel;
    public const int MAX_SCORE = 5;

<<<<<<< HEAD
    [SyncVar(hook = "OnChangeScore")]
    public int currentScore;
    
    // Use this for initialization
    void Start () {
        // UpdateScore();
        if (isLocalPlayer)
        {
            currentScore = 0;
        }

    }

    public void ManageScore(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentScore += amount;
        if(currentScore == MAX_SCORE)
        {
            //erstmals so
            GameManager.instance.NextLevel();
        }
    }

    public void OnChangeScore(int score)
    {
        scoreLabel.text = "Score: " + currentScore + "/" + MAX_SCORE;
    }
=======
	// Use this for initialization
	void Start () {
        updateScore();
>>>>>>> parent of ed3b1f8... Merge branch 'new_from_master_merged_nadia20180722' of https://github.com/dltcls/unity_3D into new_from_master_merged_nadia20180722

    public int GetCurrentScore()
    {
       return currentScore;
    }

<<<<<<< HEAD
    

    /*public void UpdateScore()
=======
    public void updateScore()
>>>>>>> parent of ed3b1f8... Merge branch 'new_from_master_merged_nadia20180722' of https://github.com/dltcls/unity_3D into new_from_master_merged_nadia20180722
    {
        //Updates the text of the score on Level1 screen
        scoreLabel.text = "Score: " + GameManager.instance.score + "/" + MAX_SCORE;
    }*/
	

   
	// Update is called once per frame
	void FixedUpdate () {
<<<<<<< HEAD
        showScore();
=======
        updateScore();
>>>>>>> parent of ed3b1f8... Merge branch 'new_from_master_merged_nadia20180722' of https://github.com/dltcls/unity_3D into new_from_master_merged_nadia20180722
		
	}

    private void showScore()
    {
        scoreLabel.text = "Score: " + currentScore + "/" + MAX_SCORE;
    }


}
