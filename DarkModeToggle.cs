using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkModeToggle : MonoBehaviour {

    public int bIsToggleOn;
    
    void Start ()
    {
        
        bIsToggleOn = PlayerPrefs.GetInt("Settings_DarkMode");

        if (bIsToggleOn == 0)
        {
            // bright
        }
        else
        {
            // dark
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
            //bright
        }
        else
        {
            //dark
        }
    }
}
