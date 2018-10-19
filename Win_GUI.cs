using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Win_GUI : MonoBehaviour {

    public MainGameManager GameManager;

    public Animator Win_GUI_Anim;
    //public Animator Camera_Anim;
    public Animator BAR_GUI_Anim;
    public Animator MainGame_Anim;

    public GameObject gO;
    public GameManager instance;
    public Text Fin_Time_Text;
    public GameObject Continue_Button;
    public Text Win_Title_Text;
    public Text Best_Time_Text;

    public string NewBestTitle;
    public string OopsTitle;

    private Timer timer;
    private bool bIsDone = false;
    private bool bLoadScene = false;
    private bool bIsQuit = false;

	void Start ()
    {
        if (!instance)
        {
            instance = FindObjectOfType<GameManager>();
        }

        if (!GameManager)
        {
            GameManager = FindObjectOfType<MainGameManager>();
        }
        if (!GameManager.bWin)
        {
            gO.SetActive(false);
            Win_GUI_Anim.SetBool("Start", true);
        }
        if (!timer)
        {
            timer = FindObjectOfType<Timer>();
        }
	}
	
	void Update ()
    {
        if (GameManager.bWin && !bIsDone)
        {
            gO.SetActive(true);
            Win_GUI_Anim.SetBool("Start", false);
            //Camera_Anim.SetBool("Start", false);
            MainGame_Anim.SetBool("Start", false);
            BAR_GUI_Anim.SetBool("Start", false);

            if (GameManager.bChallengeWin)
            {
                if (timer.bIsDone)
                {
                    //SwitchWinTitle(GameManager.bIsNewBest);
                }
            }

            bIsDone = true;
        }

        if (bLoadScene)
        {
            if( Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).IsName("Win_GUI") &&
                Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                if (bIsQuit)
                {
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    if(instance.GameMode == 2)
                    {
                        SceneManager.LoadScene("TutorialScene");
                    }
                    else
                    {
                        SceneManager.LoadScene("ChallengeScene");
                    }
                }
                bLoadScene = false;
            }
        }

        if (timer)
        {
            Fin_Time_Text.text = timer.Timer_Text.text;
        }
	}

    public void ContinueButton()
    {
        Win_GUI_Anim.SetBool("Start", true);
        bLoadScene = true;
        bIsQuit = false;
    }

    public void QuitButton()
    {
        Win_GUI_Anim.SetBool("Start", true);
        bLoadScene = true;
        bIsQuit = true;
        
        if(instance.GameMode == 0)
        {
            //GameManager.ResetChallengeData();
           
            if (GameManager.bChallengeWin)
            {
                instance.DeleteFile();
            }
            else
            {
                instance.SaveGame();
            }
        }
    }

    public void SwitchWinTitle(bool winStatus)
    {
        Continue_Button.gameObject.SetActive(false);
        Win_Title_Text.gameObject.SetActive(true);
        Best_Time_Text.gameObject.SetActive(true);

        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Best_Time"));
        Best_Time_Text.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        
        if (winStatus)
        {
            // New Best!
            Win_Title_Text.text = NewBestTitle;
        }
        else
        {
            // oops..
            Win_Title_Text.text = OopsTitle;
        }
        
    }

}
