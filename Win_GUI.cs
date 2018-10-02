using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win_GUI : MonoBehaviour {

    public MainGameManager GameManager;

    public Animator Win_GUI_Anim;
    public Animator Camera_Anim;
    public Animator BAR_GUI_Anim;

    public GameObject gO;
    public Text Fin_Time_Text;

    private Timer timer;
    private bool bIsDone = false;
    private bool bLoadScene = false;

	void Start ()
    {
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
            Camera_Anim.SetBool("Start", false);
            BAR_GUI_Anim.SetBool("Start", false);
            bIsDone = true;
        }

        if (bLoadScene)
        {
            if( Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).IsName("Win_GUI") &&
                Win_GUI_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                SceneManager.LoadScene("ChallengeScene");
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
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
