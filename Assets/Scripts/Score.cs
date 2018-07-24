﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Score : NetworkBehaviour {

    public const int maxScore = 10;

    //score derzeit in GameManager
    [SyncVar(hook = "OnCatchAdd")]
    public int currentScore;
    //label derzeit in ScoreManager
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

        if(currentScore == maxScore)
        {
            currentScore = maxScore;
            // called on the Server, but invoked on the Clients
            RpcPlayerWin();
        }
    }

    public void OnCatchAdd(int score)
    {
        scoreLabel.text = "Score: " + currentScore+ "/" + 10;
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
