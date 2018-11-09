using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

    public float timer_f;
    private string timerText;
    public Text Timer_Text;
    MainGameManager GameManager;
    GameManager instance;
    public Win_GUI win_gui;

    public bool bIsDone = false;

    void Start ()
    {
        instance = FindObjectOfType<GameManager>();
        GameManager = FindObjectOfType<MainGameManager>();
        win_gui = FindObjectOfType<Win_GUI>();

        if (instance.GameMode == 0)
        {
            timer_f = instance.CurrentTime;
        }
	}
	
	void Update ()
    {
        if(instance.GameMode == 0)
        {
            // Challenge Mode
            if (!GameManager.TimeStop)
            {
                timer_f += Time.deltaTime;
                TimeSpan timeSpan = TimeSpan.FromSeconds(timer_f);
                timerText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                Timer_Text.text = timerText;
            }

            if (GameManager.bChallengeWin && !bIsDone)
            {
                CheckBestTime();
                bIsDone = true;
            }

        }
        else if(instance.GameMode == 1)
        {
            // Training Mode
            // Check Timer is enable or disable
            if (PlayerPrefs.GetInt("Training_Timer") == 1)
            {
                if (!GameManager.TimeStop)
                {
                    timer_f += Time.deltaTime;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(timer_f);
                    timerText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                    Timer_Text.text = timerText;
                }
            }
        }
    }

    void CheckBestTime()
    {
        float timer_best = PlayerPrefs.GetFloat("Best_Time", 1000000);

        if (timer_f < timer_best)
        {
            // new best!
            PlayerPrefs.SetFloat("Best_Time", timer_f);
            win_gui.SwitchWinTitle(true);
            GameManager.bIsNewBest = true;
            UpdateLeaderBoardScore((long)timer_f * 1000);
        }
        else
        {
            // oops..
            win_gui.SwitchWinTitle(false);
            GameManager.bIsNewBest = false;
        }
    }

    void UpdateLeaderBoardScore(long Score)
    {
        PlayGameScripts.AddScoreToLeaderboard(GPGSIds.leaderboard_leaderboard,Score);
    }

}
