using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public int Tips = 1;
    public BlockHolder[] bH;
    public Animator Tips_Anim;
    public Text Tips_Text;

    private bool bIsSwitch = false;
    
	void Start ()
    {
        Tips_Text.text = "Drag the blue block and finish the calculation";
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
        if (bH[0].CurrentBlockNumber > 0 && bH[1].CurrentBlockNumber > 0)
        {
            Tips++;
            Tips_Function(Tips);
            bIsSwitch = true;
        }
    }

    void Tips_Function(int tip)
    {
        switch (tip)
        {
            case 1:

                break;
            case 2:
                Tips_Anim.SetBool("bIsTip2", true);
                Tips_Text.text = "Press the round button and change the operators";
                break;
        }


    }

}
