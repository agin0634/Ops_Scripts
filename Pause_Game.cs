using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Game : MonoBehaviour {

    public Animator BAR_GUI_Anim;
    public Animator Camera_Anim;
    public Animator Win_GUI_Anim;
    public Animator Settings_GUI_Anim;

    public GameManager instance;
    public GameObject Pause_UI;
    public MainGameManager GameManager;

    private bool bIsAnimStop = true;
    private bool bIsRestart = false;
    private bool bIsExit = false;
    private bool bIsSettings = false;
    private bool bIsPaused = false;

    void Start()
    {
        instance = FindObjectOfType<GameManager>();
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

        if (bIsPaused)
        {
            if (!GameManager.TimeStop && !bIsSettings)
            {
                ShowPauseUI();
            }
            bIsPaused = false;
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
        if (bIsRestart || bIsExit || bIsSettings)
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

        if (instance.GameMode == 0)
        {
            GameManager.ResetChallengeData();
            // TODO Waring ui
        }
    }

    public void Home()
    {
        bIsExit = true;
        HidePauseUI();

        if(instance.GameMode == 0)
        {
            GameManager.ResetChallengeData();
            // TODO Waring ui
        }
    }

    public void Settings()
    {
        bIsSettings = true;
        HidePauseUI();
        Settings_GUI_Anim.SetBool("SettingPressed", true);
    }

    public void SettingsBack()
    {
        bIsSettings = false;
        Settings_GUI_Anim.SetBool("SettingPressed", false);
        Win_GUI_Anim.SetBool("Start", false);
        Pause_UI.gameObject.SetActive(true);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        bIsPaused = true;
    }

}
