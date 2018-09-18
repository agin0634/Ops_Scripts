using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private bool bIsButtonPressed = false;
    public Animator ChallengeAm;
    public Animator TrainingAm;
    public Animator SettingsAm; 

    void Update()
    {
        if (bIsButtonPressed)
        {
            ChallengeAm.SetBool("ButtonPressed", true);
            TrainingAm.SetBool("ButtonPressed", true);
            SettingsAm.SetBool("ButtonPressed", true);
            bIsButtonPressed = false;
        }
    }

    public void PlayChallengeMode()
    {
        bIsButtonPressed = true;
    }

    public void PlayTraning()
    {
        bIsButtonPressed = true;
    }

    public void PlaySettings()
    {
        bIsButtonPressed = true;
    }
}
