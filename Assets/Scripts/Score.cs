using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Score : MonoBehaviour {

    public const int MAX_SCORE = 5; //max number of coins

    [SyncVar (hook ="OnChangeScore")]
    public int currentScore;

    void Start()
    {
        /*if (isLocalPlayer)
        {
            currentScore = 0;
        }*/
    }

    
    void ManageScoring(int amount)
    {
       /* if (!isServer)
        {
            return;
        }*/

        currentScore += amount;
        if(currentScore == MAX_SCORE)
        {
            //Continous to next level / Win Menu
            GameManager.instance.NextLevel();
        } 
    }

    public void OnChangeScore()
    {
        ScoreManager.instance.UpdateScore();
    }
}
