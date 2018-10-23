using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    public int Tips = 1;
    public BlockHolder[] bH;
    public Animator Tips_Anim;
    public Text Tips_Text;

    private GameManager instance;
    private bool bIsSwitch = false;
    
	void Start ()
    {
        instance = FindObjectOfType<GameManager>();
        
        if (instance.Difficulty == 4)
        {
            Tips = 3;
            Tips_Function(Tips);
        }
        else
        {
            Tips = 1;
            Tips_Function(Tips);
        }
    }
	
	void Update ()
    {
        if (!bIsSwitch)
        {
            SwitchTips();
        }
	}
        
    void SwitchTips()
    {
        if(instance.Difficulty == 4)
        {
            // Scene 2
            if (bH[2].CurrentBlockNumber > 0 && bH[3].CurrentBlockNumber > 0 && Tips == 3)
            {
                Tips = 5;
                Tips_Function(Tips);
            }
            if(bH[4].CurrentBlockNumber > 0 && Tips == 5)
            {
                Tips = 0;
                Tips_Function(Tips);
            }
        }
        else
        {
            // Scene 1
            if (bH[0].CurrentBlockNumber > 0 && bH[1].CurrentBlockNumber > 0 && Tips == 1)
            {
                Tips++;
                Tips_Function(Tips);
            }
        }
    }

    void Tips_Function(int tip)
    {
        switch (tip)
        {
            case 1:
                Tips_Anim.SetBool("bIsTip1", true);
                Tips_Text.text = "Drag the blue block and finish the calculation";
                break;
            case 2:
                Tips_Anim.SetBool("bIsTip2", true);
                Tips_Text.text = "Press the round button and change the operators";
                break;
            case 3:
                Tips_Anim.SetBool("bIsTip3", true);
                Tips_Text.text = "Drag the blue block and finish the calculation";
                break;
            case 5:
                Tips_Anim.SetBool("bIsTip5", true);
                Tips_Text.text = "Drag the yellow block into the calculation";
                break;
            case 0:
                Tips_Anim.SetBool("bIsTip0", true);
                Tips_Anim.SetBool("bIsTip3", false);
                Tips_Text.text = "Finish the calculation";
                bIsSwitch = true;
                break;
        }
    }
}
