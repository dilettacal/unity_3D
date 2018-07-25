using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Klasse zur Steuerung der Punkte - Multiplayer
public class Score : NetworkBehaviour {

    public const int maxScore = 5;
    
    [SyncVar(hook = "OnCatchAdd")]
    public int currentScore;
    
    public Text scoreLabel;

    void Start()
    {
        if (isLocalPlayer)
        {
            currentScore = 0;
        }
    }

    public void AddNewScore(int score)
    {
        Debug.Log("SCore: " + currentScore);
        if (!isServer)
        {
            return;
        }

        currentScore += score;
        Debug.Log("Neues SCore: " + currentScore);
        // OnCatchAdd(currentScore);
        //new solution - 2018-08-24
        GameManager.instance.score = currentScore;
        GameManager.instance.ScoreToGUI(currentScore);
        if(currentScore == maxScore)
        {
            currentScore = maxScore;
            // called on the Server, but invoked on the Clients
            RpcPlayerWin();
        }
    }

    public void OnCatchAdd(int score)
    {    
        scoreLabel.text = "Score: " + GameManager.instance.score.ToString() + "/" + maxScore;
        Debug.Log(scoreLabel.text);
    }


    [ClientRpc]
    void RpcPlayerWin()
    {
        if (isLocalPlayer)
        {
            GameManager.instance.NextLevel();

        }
 
    }
}
