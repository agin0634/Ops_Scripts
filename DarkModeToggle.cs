using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkModeToggle : MonoBehaviour {

    public int bIsToggleOn;
    public DarkMode_Main DK_Main;
    
    void Start ()
    {

        if (!DK_Main)
        {
            DK_Main = FindObjectOfType<DarkMode_Main>();
        }
        
        bIsToggleOn = PlayerPrefs.GetInt("Settings_DarkMode");

        if (bIsToggleOn == 0)
        {
            DK_Main.DarkOff();
        }
        else
        {
            DK_Main.DarkOn();
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
            DK_Main.DarkOff();
        }
        else
        {
            DK_Main.DarkOn();
        }
    }
}
