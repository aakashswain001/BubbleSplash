using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public static gameManager instance;
    bool gameOver;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
   

    // Use this for initialization
    void Start () {
        gameOver = true;
	}
    public void gameStart()
    {
        GameObject.Find("BubbleSpawner").GetComponent<BubbleSpawner>().StartSpawingBalls();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameOver()
    {  //stop score not added
        gameOver = false;

        GameObject.Find("BubbleSpawner").GetComponent<BubbleSpawner>().StopSpawningBalls();
        
        UiManager.instance.GameOver();
    }
}
