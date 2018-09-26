﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGUI : MonoBehaviour {

    public MainGameManager GameManager;
    public Text TargetNumberText;
    public Animator TargetCircle_Anim;
    public Animator Target_GUI_Anim;
    public Animator Camera_Anim;
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
    }

    public void Go()
    {
        Target_GUI_Anim.SetBool("Start", true);
        Camera_Anim.SetBool("Start", true);
    }
}
