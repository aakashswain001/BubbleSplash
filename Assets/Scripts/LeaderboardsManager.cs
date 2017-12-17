using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderboardsManager : MonoBehaviour {
    public static LeaderboardsManager instance;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        PlayGamesPlatform.Activate();
        // Login();
        Invoke("Login", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Login() {
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if (PlayerPrefs.HasKey("HighScore0"))
            {
                Social.ReportScore(PlayerPrefs.GetInt("HighScore0"), Leaderboards.leaderboard_leaderboards, (bool success0) => { });
            }
        });
    }
    public void ShowLeaderboards() {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(Leaderboards.leaderboard_leaderboards);
        }
        else {
            Login();
        }
    }
    public void AddScoreToLeaderboards() {
        if (Social.localUser.authenticated)
        { // post score 12345 to leaderboard ID "Cfji293fjsie_QA")
            Social.ReportScore((int)ScoreManager.instance.Score, Leaderboards.leaderboard_leaderboards, (bool success) =>
            {
                // handle success or failure
            });
        }
        else {
            Login();
        }
    }
}
