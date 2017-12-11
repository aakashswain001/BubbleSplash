using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public static gameManager instance;
    public bool gameOver;

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
        gameOver = false;
        //UiManager.instance.instructions();
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
        GameObject.Find("BubbleSpawner").GetComponent<BubbleSpawner>().StopSpawningBalls();      
        UiManager.instance.GameOver();
    }
}
