using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeMenu : MonoBehaviour {

    public GameManager instance;

    public Animator SubMenuAnim;
    public Animator GameLogoAnim;

    private bool bIsAnimExit = false;

    void Start ()
    {
        instance = FindObjectOfType<GameManager>();
    }
	
	void FixedUpdate ()
    {

        if (bIsAnimExit)
        {
            if (GameLogoAnim.GetCurrentAnimatorStateInfo(0).IsName("GameLogoExit") &&
                GameLogoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                SceneManager.LoadScene("ChallengeScene");
                bIsAnimExit = false;
            }
        }
    }

    public void ChallengeStart()
    {
        SubMenuAnim.SetBool("ButtonPressed", false);
        GameLogoAnim.SetBool("LogoExit", true);
        bIsAnimExit = true;
        instance.GameMode = 0;
    }
}
