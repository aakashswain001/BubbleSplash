using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject settingPanel,soundON,soundOFF,sfxON,sfxOFF;
    public int sound=0, sfx=0;
    bool settingState = false;
	// Use this for initialization
	void Start () {


        //Audio Settings Part
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 0);
        }
        else {
           sound = PlayerPrefs.GetInt("sound");
        }
        if (!PlayerPrefs.HasKey("sfx"))
        {
            PlayerPrefs.SetInt("sfx", 0);
        }
        else {
          sfx = PlayerPrefs.GetInt("sfx");
        }
        UpdateSettingsPanel();
	}
	
	// Update is called once per frame
	void Update () {

    }
     public void StartGame() {
       
        SceneManager.LoadScene("BubbleSplash");
    }
    public void Settings()
    {
        if (!settingState)
        {
            settingPanel.SetActive(true);
            settingState = true;
        }
        else {
            settingPanel.SetActive(false);
            settingState = false;
        }
    }
    void UpdateSettingsPanel() {
        if (sound == 0)
        {
            soundON.SetActive(true);
            soundOFF.SetActive(false);
        }
        else {
            soundON.SetActive(false);
            soundOFF.SetActive(true);
        }
        if (sfx == 0)
        {
            sfxON.SetActive(true);
            sfxOFF.SetActive(false);
        }
        else {
            sfxON.SetActive(false);
            sfxOFF.SetActive(true);
        }
    }
    public void soundOn() {
        //In sound On button click we will off the sound
        sound = 1;
        PlayerPrefs.SetInt("sound", 1);
        UpdateSettingsPanel();
    }
    public void soundOff() {
        sound = 0;
        PlayerPrefs.SetInt("sound", 0);
        UpdateSettingsPanel();
    }
    public void sfxOn() {
        sfx = 1;
        PlayerPrefs.SetInt("sfx", 1);
        UpdateSettingsPanel();
    }
    public void sfxOff() {
        sfx = 0;
        PlayerPrefs.SetInt("sfx", 0);
        UpdateSettingsPanel();
    }
}
