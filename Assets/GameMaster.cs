﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private int nextUpdate = 1;
    public int score = 0;
	public int gameWinScore = 300;
    public int scorePerSecond = 1;
    public float TimeBetween = 30f;
    public float timer;
    public bool CountTimerDown = true;
	public GameObject gameOverScene;
	public GameObject gameWinScene;
	public Text scoreText;

    private bool addScore;

    private void Start()
    {
        addScore = true;
        timer = TimeBetween;
    }
    
    void Update () {
        if (timer <= 0)
        {
            GameOver();
        }
        if (Time.time >= nextUpdate && addScore)
        {
            AddPoints(scorePerSecond);
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        }
        timer -= Time.deltaTime;

    }

    internal void AddPoints(int addScore)
    {
        score += addScore;
		scoreText.text = "Score: " + score;
		if(score == gameWinScore) {
			GameWin();
		}
    }

    internal void ResetTimer()
    {
        if (CountTimerDown)
        {
            if(TimeBetween > 5f)
            {
                TimeBetween = TimeBetween - 5f;
            }
            timer += TimeBetween;
        }
    }

    internal void GameOver()
    {
        gameOverScene.SetActive(true);
    }

	internal void GameWin() {
		gameWinScene.SetActive(true);
	}
}
