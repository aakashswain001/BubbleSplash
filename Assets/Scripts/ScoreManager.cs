using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;
    private float score;
    public float Score;
    public bool isHighScore;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        isHighScore = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.instance.gameOver)
        {
            score += Time.deltaTime;
            Score = (int)score + 0;
        }
        else {
            if (PlayerPrefs.HasKey("HighScore0"))
            {
                if (Score > PlayerPrefs.GetInt("HighScore0"))
                {
                    PlayerPrefs.SetInt("HighScore0", (int)Score);
                    isHighScore = true;
                }
            }
            else {
                PlayerPrefs.SetInt("HighScore0", (int)Score);
                isHighScore = true;
            }
        }
    }
    public void incrementScore() {
        score = score + 2;
    }
}
