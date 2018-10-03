using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public static AudioSource aS = null;
    public int bIsToggleOn;

	// Use this for initialization
	void Start ()
    {
        
        if (aS == null)
        {
            aS = gameObject.GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (aS)
        {

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
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
