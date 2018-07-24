using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreLabel;
    public const int MAX_SCORE = 5;
    public static ScoreManager instance = null;

<<<<<<< HEAD
<<<<<<< HEAD
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
=======
    void Awake()
>>>>>>> parent of 26f3c2a... Some changes
=======
    void Awake()
>>>>>>> parent of 26f3c2a... Some changes
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
=======
	// Use this for initialization
	void Start () {
        updateScore();
>>>>>>> parent of ed3b1f8... Merge branch 'new_from_master_merged_nadia20180722' of https://github.com/dltcls/unity_3D into new_from_master_merged_nadia20180722

    // Use this for initialization
    void Start () {
       UpdateScore();

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    

    /*public void UpdateScore()
=======
    public void updateScore()
>>>>>>> parent of ed3b1f8... Merge branch 'new_from_master_merged_nadia20180722' of https://github.com/dltcls/unity_3D into new_from_master_merged_nadia20180722
=======
    }

    public void UpdateScore()
>>>>>>> parent of 26f3c2a... Some changes
=======
    }

    public void UpdateScore()
>>>>>>> parent of 26f3c2a... Some changes
    {
        //Updates the text of the score on Level1 screen
        scoreLabel.text = "Score: " + GameManager.instance.score + "/" + MAX_SCORE;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        showScore();
=======
        updateScore();
>>>>>>> parent of ed3b1f8... Merge branch 'new_from_master_merged_nadia20180722' of https://github.com/dltcls/unity_3D into new_from_master_merged_nadia20180722
=======
        UpdateScore();
>>>>>>> parent of 26f3c2a... Some changes
=======
        UpdateScore();
>>>>>>> parent of 26f3c2a... Some changes
		
	}
}
