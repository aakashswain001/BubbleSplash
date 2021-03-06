﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public static gameManager instance;
    public bool gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   

    // Use this for initialization
    void Start () {
        gameOver = false;
    }
    public void gameStart()
    {
       GameObject.Find("BubbleSpawner").GetComponent<BubbleSpawner>().StartSpawingBalls();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call<bool>("moveTaskToBack", true);
            }
            else
            {
                Application.Quit();
            }
        }
    }
    public void GameOver()
    {  //stop score not added
        gameOver = true;
        ScoreMultiplier.instance.GameOver();
        if (AudioManager.instance.sfx == true)
        {
            AudioManager.instance.Play("gameover");
        }
        if (AudioManager.instance.background == true)
        {
            AudioManager.instance.Stop("game");
        }
        GameObject.Find("BubbleSpawner").GetComponent<BubbleSpawner>().StopSpawningBalls();      
        UiManager.instance.GameOver();
        UnityAdsManager.instance.ShowAd();
        LeaderboardsManager1.instance.AddScoreToLeaderboards();
       
    }
}
