using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGUI : MonoBehaviour {

    public MainGameManager GameManager;
    public Text TargetNumberText;

    public Animator TargetCircle_Anim;
    public Animator Target_GUI_Anim;
    public Animator Camera_Anim;
    public Animator BAR_GUI_Anim;

    public GameObject Go_Button;
    private bool bIsDone = false;
    
	void Start ()
    {
        if (!GameManager)
        {
            GameManager = FindObjectOfType<MainGameManager>();
        }
	}
	
	void FixedUpdate ()
    {
        if (GameManager && !bIsDone)
        {
            TargetNumberText.text = GameManager.GetComponent<TargetNumber>().Target_Number.ToString();
            if (TargetCircle_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 2)
            {
                Go_Button.transform.gameObject.SetActive(true);
                bIsDone = true;
            }
        }

        if (Target_GUI_Anim.GetCurrentAnimatorStateInfo(0).IsName("Target_GUI") &&
            Target_GUI_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    public void Go()
    {
        Target_GUI_Anim.SetBool("Start", true);
        Camera_Anim.SetBool("Start", true);
        BAR_GUI_Anim.SetBool("Start", true);
        GameManager.TimeStop = false;
    }
}
