using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    public static UiManager instance;
    public Text scoreText;
    public GameObject GameOverPanel;
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

        scoreText.text = ScoreManager.instance.Score.ToString();
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
       // background.SetLayoutDirty();
    }
    public void Replay()
    {
        SceneManager.LoadScene("BubbleSplash");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
