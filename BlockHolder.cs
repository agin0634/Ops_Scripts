using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour {

    public bool bIsEmpty = true;
    public bool bIsSomethingTrigger = false;
    public MoveBlock CurrentBlock = null;
    public MoveBlock PreviousBlock = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Block_M")
        {
            bIsSomethingTrigger = true;
            CurrentBlock = Col.GetComponent<MoveBlock>();
            if (!CurrentBlock.bIsBeHolding)
            {
                CurrentBlock.bIsBeHolding = true;
                CurrentBlock.CurrentHolder = this;
            }
        }
    }

    void OnTriggerExit2D(Collider2D Col)
    {
        if(Col.GetComponent<MoveBlock>() == CurrentBlock)
        {
            CurrentBlock = null;
            bIsSomethingTrigger = false;
        }
    }

}
