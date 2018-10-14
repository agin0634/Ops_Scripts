using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour {

    public int bIsToggleOn;
    public float SFX_Volume;
        
    void Start ()
    {
        if (bIsToggleOn == 0)
        {
           SFX_Volume = 0;
        }
        else
        {
           SFX_Volume = 0.5f;
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
            SFX_Volume = 0;
        }
        else
        {
            SFX_Volume = 0.5f;
        }
    }
}
