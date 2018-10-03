using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_UI : MonoBehaviour {

    public Pause_Game pG;
    private bool bIsAnimStop = true;
    
	void Start ()
    {
        if (!pG)
        {
            pG = FindObjectOfType<Pause_Game>();
        }
	}
	
	void Update ()
    {
		if(!bIsAnimStop && pG.Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            bIsAnimStop = true;
            SceneManager.LoadScene("ChallengeScene");
        }
	}

    public void Unpause()
    {
        pG.HidePauseUI();
    }

    public void Restart()
    {
        pG.Win_GUI_Anim.SetBool("Start", true);
        bIsAnimStop = false;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
