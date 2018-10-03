using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkModeToggle : MonoBehaviour {

    public int bIsToggleOn;
    public DarkMode_Main DK_Main;
    public DarkMode_Game DK_Game;
    
    void Start ()
    {

        if (!DK_Main)
        {
            DK_Main = FindObjectOfType<DarkMode_Main>();
            DK_Game = FindObjectOfType<DarkMode_Game>();
        }
        
        bIsToggleOn = PlayerPrefs.GetInt("Settings_DarkMode");

        if (bIsToggleOn == 0)
        {
            if (DK_Main)
            {
                DK_Main.DarkOff();
            }
            if (DK_Game)
            {
                DK_Game.DarkOff();
            }
        }
        else
        {
            if (DK_Main)
            {
                DK_Main.DarkOn();
            }
            if (DK_Game)
            {
                DK_Game.DarkOn();
            }
        }

    }
	
	void Update ()
    {
        if (PlayerPrefs.GetInt("Settings_DarkMode") != bIsToggleOn)
        {
            bIsToggleOn = PlayerPrefs.GetInt("Settings_DarkMode");
            SwitchToggle();
        }
    }

    void SwitchToggle()
    {
        if (bIsToggleOn == 0)
        {
            if (DK_Main)
            {
                DK_Main.DarkOff();
            }
            if (DK_Game)
            {
                DK_Game.DarkOff();
            }
        }
        else
        {
            if (DK_Main)
            {
                DK_Main.DarkOn();
            }
            if (DK_Game)
            {
                DK_Game.DarkOn();
            }
        }
    }
}
