using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public GameManager instance;
    public Animator SubMenuAnim;
    public Animator GameLogoAnim;
    private bool bIsAnimExit = false;

    void Start ()
    {
        instance = FindObjectOfType<GameManager>();

        if (PlayerPrefs.GetInt("IsNotFirstTime") == 0)
        {
            instance.GameMode = 2;
            instance.Difficulty = 2;
            SceneManager.LoadScene("TutorialScene");
        }
	}

    void FixedUpdate()
    {
        if (bIsAnimExit)
        {
            if (GameLogoAnim.GetCurrentAnimatorStateInfo(0).IsName("GameLogoExit") &&
                GameLogoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                SceneManager.LoadScene("TutorialScene");
                bIsAnimExit = false;
            }
        }
    }

    public void OpenTutorial()
    {
        SubMenuAnim.SetBool("ButtonPressed", false);
        GameLogoAnim.SetBool("LogoExit", true);
        instance.GameMode = 2;
        instance.Difficulty = 2;
        bIsAnimExit = true;
    }
}
