using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour {
    public static AchievementManager instance;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Login() {
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
        });

    }
    public void ShowAchievement() {
        Social.ShowAchievementsUI();
    }
    public void CheckAchievement() {
        // unlock achievement (achievement ID "Cfjewijawiu_QA")
        if (ScoreManager.instance.Score > 10) {
            Social.ReportProgress(Achievements.achievement_starter, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 30)
        {
            Social.ReportProgress(Achievements.achievement_beginner, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 50)
        {
            Social.ReportProgress(Achievements.achievement_silver, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 100)
        {
            Social.ReportProgress(Achievements.achievement_silver_elite, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 150)
        {
            Social.ReportProgress(Achievements.achievement_silver_elite_master, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 200)
        {
            Social.ReportProgress(Achievements.achievement_gold_nova, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 500)
        {
            Social.ReportProgress(Achievements.achievement_elite, 100.0f, (bool success) => {
            });
        }
        if (ScoreManager.instance.Score > 500)
        {
            Social.ReportProgress(Achievements.achievement_global_elite, 100.0f, (bool success) => {
            });
        }
    }
}
