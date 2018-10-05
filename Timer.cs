using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour {

    float timer_f;
    string timerText;
    public Text Timer_Text;
    MainGameManager GameManager;
    GameManager instance;

    void Start ()
    {
        instance = FindObjectOfType<GameManager>();
        GameManager = FindObjectOfType<MainGameManager>();
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
}
