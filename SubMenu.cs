using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour {

    public GameObject Training_Timer_Toggle;
    public GameObject Settings_SFX_Toggle;
    public GameObject Settings_BGM_Toggle;
    public GameObject Settings_DarkMode_Toggle;

    [SerializeField]
    public bool bIsFirstTime = true;

    [SerializeField]
    public int Traing_Timer;
    [SerializeField]
    public int Settings_SFX;
    [SerializeField]
    public int Settings_BGM;
    [SerializeField]
    public int Settings_DarkMode;

    public void Awake()
    {
        // Training Menu
        //Traing_Timer = PlayerPrefs.GetInt("Training_Timer");
        Training_Timer_Toggle.GetComponent<ToggleCheck>().isOn = Traing_Timer;

        // Settings Menu
        //Settings_SFX = PlayerPrefs.GetInt("Settings_SFX");
        Settings_SFX_Toggle.GetComponent<ToggleCheck>().isOn = Settings_SFX;

        //Settings_BGM = PlayerPrefs.GetInt("Settings_BGM");
        Settings_BGM_Toggle.GetComponent<ToggleCheck>().isOn = Settings_BGM;

        //Settings_DarkMode = PlayerPrefs.GetInt("Settings_DarkMode");
        Settings_DarkMode_Toggle.GetComponent<ToggleCheck>().isOn = Settings_DarkMode;

        if(bIsFirstTime){
            Training_Timer_Toggle.GetComponent<ToggleCheck>().isOn = 1;
            Settings_SFX_Toggle.GetComponent<ToggleCheck>().isOn = 1;
            Settings_BGM_Toggle.GetComponent<ToggleCheck>().isOn = 1;
            Settings_DarkMode_Toggle.GetComponent<ToggleCheck>().isOn = 0;
            bIsFirstTime = false;
        }

    }
    
	void Start ()
    {
        
    }
	
	void Update ()
    {
		
	}

    public void Training_Timer_Change_Value()
    {
        switch (Training_Timer_Toggle.GetComponent<ToggleCheck>().isOn)
        {
            case 1:
                Traing_Timer = 0;
                break;

            case 0:
                Traing_Timer = 1;
                break;
        }
       
        PlayerPrefs.SetInt("Training_Timer", Traing_Timer);
        PlayerPrefs.Save();
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
