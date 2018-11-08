using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameManager instance;
    private AdmodManager admodManager;

    private bool bIsButtonPressed = false;
    private bool bAnimationPlaying = false;
    private bool bCanRunProgress = true;
    private bool bIsFirstTime = true;
    private bool bIsChallengeStart = false;
    public float AnimSpeed = 1.0f;
    public Animator ChallengeAnim;
    public Animator TrainingAnim;
    public Animator SettingsAnim;
    public Animator ToolBarAnim;
    public Animator SubMenuAnim;
    public Animator GameLogoAnim;

    void Start()
    {
        instance = FindObjectOfType<GameManager>();
        admodManager = FindObjectOfType<AdmodManager>();

        admodManager.ShowBanner();
    }

    void Update()
    {
        if (bIsButtonPressed)
        {
            if (!bAnimationPlaying)
            {
                if (bIsFirstTime)
                {
                    bIsFirstTime = false;
                    ChallengeAnim.speed = AnimSpeed;
                    TrainingAnim.speed = AnimSpeed;
                    SettingsAnim.speed = AnimSpeed;
                    ToolBarAnim.speed = AnimSpeed;
                    SubMenuAnim.speed = AnimSpeed;
                }

                if (bIsChallengeStart)
                {
                    GameLogoAnim.SetBool("ChallengeStart", true);
                }

                ChallengeAnim.SetBool("ButtonPressed", true);
                TrainingAnim.SetBool("ButtonPressed", true);
                SettingsAnim.SetBool("ButtonPressed", true);
                ToolBarAnim.SetBool("ButtonPressed", true);
                SubMenuAnim.SetBool("ButtonPressed", true);
                bIsButtonPressed = false;
            }      
        }

        if (SettingsAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            bAnimationPlaying = true;
            bCanRunProgress = true;
        }
        else
        {
            if (bCanRunProgress)
            {
                bAnimationPlaying = false;
                bCanRunProgress = false;
                if (SubMenuAnim.GetCurrentAnimatorStateInfo(0).IsName("SubMenu"))
                {
                    SetSubMenuActive();
                }
            }
        }

        if (bIsChallengeStart && GameLogoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 &&
            GameLogoAnim.GetCurrentAnimatorStateInfo(0).IsName("GameLogo_Challenge"))
        {
            instance.GameMode = 0;
            if (instance.CheckSaveFile())
            {
                instance.LoadGame();
                Debug.Log("Save exist");
                SceneManager.LoadScene("ChallengeScene");
            }
            else
            {
                SceneManager.LoadScene("ChallengeScene");
                Debug.Log("New");
            }
        }
    }

    public void PlayChallengeMode()
    {
        if (!bAnimationPlaying)
        {
            bIsButtonPressed = true;
            SubMenuAnim.transform.GetChild(0).transform.gameObject.SetActive(true);
        }
    }

    public void PlayTraning()
    {
        if (!bAnimationPlaying)
        {
            bIsButtonPressed = true;
            SubMenuAnim.transform.GetChild(1).transform.gameObject.SetActive(true);
        }
    }

    public void PlaySettings()
    {
        if (!bAnimationPlaying)
        {
            bIsButtonPressed = true;
            SubMenuAnim.transform.GetChild(2).transform.gameObject.SetActive(true);
        }
    }

    public void BacktoMain()
    {
        if (!bAnimationPlaying)
        {
            ChallengeAnim.SetBool("ButtonPressed", false);
            TrainingAnim.SetBool("ButtonPressed", false);
            SettingsAnim.SetBool("ButtonPressed", false);
            ToolBarAnim.SetBool("ButtonPressed", false);
            SubMenuAnim.SetBool("ButtonPressed", false);
        }
    }

    public void ChallengeStart()
    {
        if (!bAnimationPlaying)
        {
            bIsButtonPressed = true;
            bIsChallengeStart = true;
        }
    }

    private void SetSubMenuActive()
    {
        SubMenuAnim.transform.GetChild(0).transform.gameObject.SetActive(false);
        SubMenuAnim.transform.GetChild(1).transform.gameObject.SetActive(false);
        SubMenuAnim.transform.GetChild(2).transform.gameObject.SetActive(false);
    }

    public void ShowAchievements()
    {
        PlayGameScripts.ShowAchievementsUI();
    }

    public void ShowLeaderboards()
    {
        PlayGameScripts.ShowLeaderboardUI();
    }
}
