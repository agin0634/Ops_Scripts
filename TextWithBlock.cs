using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWithBlock : MonoBehaviour {
    
    public Text NumberText;
    public int BlockNumber = 0;
    public Animator Camera_Anim;
    
    private bool bIsDone = false;

    void Start()
    {
        if (!Camera_Anim)
        {
            Camera_Anim = FindObjectOfType<Camera>().GetComponent<Animator>();
        }
        
        NumberText.GetComponent<Text>().enabled = false;
        
    }
    
    
	void FixedUpdate()
    {
        if(!bIsDone && Camera_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            NumberText.GetComponent<Text>().enabled = true;
            bIsDone = true;
        }
        
        //Vector3 NumberPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        //NumberText.transform.position = NumberPosition;

        if (BlockNumber >= 0)
        {
            if ( BlockNumber <= 999)
            {
                NumberText.fontSize = 52;
                NumberText.text = BlockNumber.ToString();
            }            
            else if(BlockNumber > 999 && BlockNumber <= 9999)
            {
                NumberText.fontSize = 48;
                NumberText.text = BlockNumber.ToString();
            }
            else if(BlockNumber > 9999 && BlockNumber <= 99999)
            {
                NumberText.fontSize = 40;
                NumberText.text = BlockNumber.ToString();
            }
            else
            {
                NumberText.fontSize = 48;
                NumberText.text = "Oops";
            }
        }
        else
        {
            NumberText.fontSize = 48;
            NumberText.text = "Oops";
        }
    }
}
