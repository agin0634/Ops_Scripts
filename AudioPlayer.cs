using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public AudioSource aS;
    public int bIsToggleOn;

	// Use this for initialization
	void Start ()
    {
        aS = gameObject.GetComponent<AudioSource>();
        
        DontDestroyOnLoad(gameObject);
        
        bIsToggleOn = PlayerPrefs.GetInt("Settings_BGM");

        if (bIsToggleOn == 0)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
	
	void Update ()
    {
		if(PlayerPrefs.GetInt("Settings_BGM") != bIsToggleOn)
        {
            bIsToggleOn = PlayerPrefs.GetInt("Settings_BGM");
            SwitchToggle();
        }
	}

    void SwitchToggle()
    {
        if (bIsToggleOn == 0)
        {
            gameObject.GetComponent<AudioSource>().Pause();
            Debug.Log("Off");
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("HO");
        }
    }
}
