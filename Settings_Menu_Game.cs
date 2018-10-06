using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Menu_Game : MonoBehaviour {

    public GameObject Settings_SFX_Toggle;
    public GameObject Settings_BGM_Toggle;
    public GameObject Settings_DarkMode_Toggle;

    public int Settings_SFX;
    public int Settings_BGM;
    public int Settings_DarkMode;

    void Awake()
    {
        // Settings Menu in Game
        Settings_SFX = PlayerPrefs.GetInt("Settings_SFX");
        Settings_SFX_Toggle.GetComponent<ToggleCheck>().isOn = Settings_SFX;

        Settings_BGM = PlayerPrefs.GetInt("Settings_BGM");
        Settings_BGM_Toggle.GetComponent<ToggleCheck>().isOn = Settings_BGM;

        Settings_DarkMode = PlayerPrefs.GetInt("Settings_DarkMode");
        Settings_DarkMode_Toggle.GetComponent<ToggleCheck>().isOn = Settings_DarkMode;
    }

    void Start ()
    {
       
    }
	
	void Update ()
    {
		
	}
    public void Settings_SFX_Change_Value()
    {
        switch (Settings_SFX_Toggle.GetComponent<ToggleCheck>().isOn)
        {
            case 1:
                Settings_SFX = 0;
                break;

            case 0:
                Settings_SFX = 1;
                break;
        }

        PlayerPrefs.SetInt("Settings_SFX", Settings_SFX);
        PlayerPrefs.Save();
    }

    public void Settings_BGM_Change_Value()
    {
        switch (Settings_BGM_Toggle.GetComponent<ToggleCheck>().isOn)
        {
            case 1:
                Settings_BGM = 0;
                break;

            case 0:
                Settings_BGM = 1;
                break;
        }

        PlayerPrefs.SetInt("Settings_BGM", Settings_BGM);
        PlayerPrefs.Save();
    }

    public void Settings_DarkMode_Change_Value()
    {
        switch (Settings_DarkMode_Toggle.GetComponent<ToggleCheck>().isOn)
        {
            case 1:
                Settings_DarkMode = 0;
                break;

            case 0:
                Settings_DarkMode = 1;
                break;
        }

        PlayerPrefs.SetInt("Settings_DarkMode", Settings_DarkMode);
        PlayerPrefs.Save();
    }
}
