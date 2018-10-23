using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameManager instance;

    private bool bIsButtonPressed = false;
    private bool bAnimationPlaying = false;
    private bool bCanRunProgress = true;
    private bool bIsFirstTime = true;
    private bool bIsChallengeStart = false;
    public float AnimSpeed = 1.0f;
    public Animator ChallengeAmin;
    public Animator TrainingAmin;
    public Animator SettingsAmin;
    public Animator SubMenuAmin;
    public Animator GameLogoAnim;

    void Start()
    {
        instance = FindObjectOfType<GameManager>();
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
                    ChallengeAmin.speed = AnimSpeed;
                    TrainingAmin.speed = AnimSpeed;
                    SettingsAmin.speed = AnimSpeed;
                    SubMenuAmin.speed = AnimSpeed;
                }

                if (bIsChallengeStart)
                {
                    GameLogoAnim.SetBool("ChallengeStart", true);
                }

                ChallengeAmin.SetBool("ButtonPressed", true);
                TrainingAmin.SetBool("ButtonPressed", true);
                SettingsAmin.SetBool("ButtonPressed", true);
                SubMenuAmin.SetBool("ButtonPressed", true);
                bIsButtonPressed = false;
            }      
        }

        if (SettingsAmin.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
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
                if (SubMenuAmin.GetCurrentAnimatorStateInfo(0).IsName("SubMenu"))
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
            SubMenuAmin.transform.GetChild(0).transform.gameObject.SetActive(true);
        }
    }

    public void PlayTraning()
    {
        if (!bAnimationPlaying)
        {
            bIsButtonPressed = true;
            SubMenuAmin.transform.GetChild(1).transform.gameObject.SetActive(true);
        }
    }

    public void PlaySettings()
    {
        if (!bAnimationPlaying)
        {
            bIsButtonPressed = true;
            SubMenuAmin.transform.GetChild(2).transform.gameObject.SetActive(true);
        }
    }

    public void BacktoMain()
    {
        if (!bAnimationPlaying)
        {
            ChallengeAmin.SetBool("ButtonPressed", false);
            TrainingAmin.SetBool("ButtonPressed", false);
            SettingsAmin.SetBool("ButtonPressed", false);
            SubMenuAmin.SetBool("ButtonPressed", false);
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
        SubMenuAmin.transform.GetChild(0).transform.gameObject.SetActive(false);
        SubMenuAmin.transform.GetChild(1).transform.gameObject.SetActive(false);
        SubMenuAmin.transform.GetChild(2).transform.gameObject.SetActive(false);
    }
}
