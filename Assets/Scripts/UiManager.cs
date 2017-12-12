using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    public static UiManager instance;
    public Text scoreText;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject GameoverScoreText, NewHighscoreText;
    //public GameObject instructionPanel;
   

    public GameObject life1, life2, life3;
    // public Image background;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.instance.gameOver) {
            scoreText.text = ScoreManager.instance.Score.ToString();
        }
    }
    public void GameOver()
    {
        scoreText.gameObject.SetActive(false);
        PauseButton.SetActive(false);
        GameOverPanel.SetActive(true);
        GameoverScoreText.GetComponent<Text>().text = ScoreManager.instance.Score.ToString();
    }
    public void HighScore() {
        NewHighscoreText.SetActive(true);
    }
    

    public void Replay()
    {
        AudioManager.instance.PlayButton("buttonclick");
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        PauseButton.SetActive(true);
        gameManager.instance.gameOver = false;
        SceneManager.LoadScene("BubbleSplash");
    }
    public void OnApplicationQuit()
    {
        AudioManager.instance.PlayButton("buttonclick");
        Application.Quit();
    }
    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame() {
        AudioManager.instance.PlayButton("buttonclick");
        AudioManager.instance.Pause("game");
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        

    }
    public void PlayPausedGame() {
        AudioManager.instance.PlayButton("buttonclick");
        AudioManager.instance.ResumeAudio("game");
        PauseButton.SetActive(true);
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void updateLifes() {
        int lifes = LifeManager.instance.lifes;
        if (lifes == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (lifes == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (lifes == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }
        else if (lifes == 0) {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }
    }
   // public void instructions()
   // {
    //    instructionPanel.SetActive(true);
    //}
}
