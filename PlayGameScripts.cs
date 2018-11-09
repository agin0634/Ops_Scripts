using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class PlayGameScripts : MonoBehaviour {
        
	void Start ()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
           .Build();

        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.Activate();

        SignIn();
    }

    void SignIn()
    {
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.TOP);
            }
        });
    }

    #region Achievements

    public static void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }

    #endregion Achievements

    #region Leaderboards

    public static void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }

    public static void AddScoreToLeaderboard(string leaderboardID, long Score)
    {
        Social.ReportScore(Score, leaderboardID, success => { });
    }

    #endregion Leaderboards

}
