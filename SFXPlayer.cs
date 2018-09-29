using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour {

    public int bIsToggleOn;
    
    void Start ()
    {

        bIsToggleOn = PlayerPrefs.GetInt("Settings_SFX");

        if (bIsToggleOn == 0)
        {
            // off
        }
        else
        {
            // on
        }

    }
	
	void Update ()
    {
        if (PlayerPrefs.GetInt("Settings_SFX") != bIsToggleOn)
        {
            bIsToggleOn = PlayerPrefs.GetInt("Settings_SFX");
            SwitchToggle();
        }

    }

    void SwitchToggle()
    {
        if (bIsToggleOn == 0)
        {
            // off
        }
        else
        {
            // on
        }
    }
}
