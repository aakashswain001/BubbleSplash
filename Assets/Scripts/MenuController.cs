﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject settingPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
     public void StartGame() {
       
        SceneManager.LoadScene("BubbleSplash");
    }
    public void Settings()
    {
        settingPanel.SetActive(true);

    }
}
