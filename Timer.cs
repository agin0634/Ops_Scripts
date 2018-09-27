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

	// Use this for initialization
	void Start () {
        GameManager = FindObjectOfType<MainGameManager>();
        instance = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
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
