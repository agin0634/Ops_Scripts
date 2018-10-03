using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Game : MonoBehaviour {

    public Animator BAR_GUI_Anim;
    public Animator Camera_Anim;
    public Animator Win_GUI_Anim;
    public GameObject Pause_UI;
    public MainGameManager GameManager;

    private bool bIsAnimStop = true;
    private bool bIsRestart = false;
    private bool bIsExit = false;

    void Start()
    {

    }

    void Update()
    {
        if (!bIsAnimStop && Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).IsName("Win_GUI") &&
            Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Pause_UI.gameObject.SetActive(false);
            bIsAnimStop = true;
            if (bIsRestart)
            {
                SceneManager.LoadScene("ChallengeScene");
            }
            if (bIsExit)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    void OnMouseDown()
    {
        ShowPauseUI();
    }

    public void ShowPauseUI()
    {
        BAR_GUI_Anim.SetBool("Start", false);
        Camera_Anim.SetBool("Start", false);
        Win_GUI_Anim.SetBool("Start", false);
        Pause_UI.gameObject.SetActive(true);
        GameManager.TimeStop = true;
    }

    public void HidePauseUI()
    {
        if (bIsRestart || bIsExit)
        {
            Win_GUI_Anim.SetBool("Start", true);
            bIsAnimStop = false;
            GameManager.TimeStop = false;
        }
        else
        {
            BAR_GUI_Anim.SetBool("Start", true);
            Camera_Anim.SetBool("Start", true);
            Win_GUI_Anim.SetBool("Start", true);
            bIsAnimStop = false;
            GameManager.TimeStop = false;
        }
    }

    public void Unpause()
    {
        HidePauseUI();
    }

    public void Restart()
    {
        bIsRestart = true;
        HidePauseUI();
    }

    public void Home()
    {
        HidePauseUI();
        bIsExit = true;
    }

}
