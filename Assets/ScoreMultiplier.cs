using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour {
    public int multiplier = 1;
    public static ScoreMultiplier instance;
    private float time;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("increaseMultiplier", 15f,10f);

    }

    // Update is called once per frame
    void Update () {
        
	}
    public void GameStart() {
        /// InvokeRepeating("increaseMultiplier", 2f,1f);
        multiplier++;
    }
    public void GameOver() {
        CancelInvoke("increaseMultiplier");
        multiplier = 1;
    }
    private void increaseMultiplier() {
        if (multiplier < 35) {
            multiplier ++;
        }
    }
}
