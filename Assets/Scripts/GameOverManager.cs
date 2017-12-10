﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public GameplayController player;
    public GameMaster gm;

    public Text finalScoreText;
    public Text finalTimeText;

    Animator gameOverAnim;

    // How long to transition to game over screen
    public float endTimer;

    bool gameIsOver = false;

    // Use this for initialization
    void Start () {
        gameOverAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.Lives <= 0 || gm.timer <=0)
        {
            gameOver();
            gameIsOver = true;
            endTimer -= Time.deltaTime;
            if (endTimer < 0)
            {
                player.gameObject.SetActive(false);
            }
        }
	}

    // Ends the game - only runs once per game
    void gameOver()
    {
        if(gameIsOver)
        {
            return;
        }
        float finalScore = gm.score;
        finalScoreText.text = "Final Score: " + finalScore.ToString("0");

        float finalTime = gm.timer;
        finalTimeText.text = "Final Time: " + finalTime.ToString("0");
        
        gameOverAnim.SetTrigger("GameOver");
    }
}
