using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBlock : MonoBehaviour {

    private MoveBlock[] mB;
    public List<MoveBlock> mB_R;

    private bool bIsDone = false;
    
	void Update ()
    {
        if (!bIsDone)
        {
            mB = FindObjectsOfType<MoveBlock>();
            
            for (int j = 0; j <= mB.Length - 1; j++)
            {
                if (mB[j].transform.gameObject.tag == "Block_M")
                {
                    mB_R.Add(mB[j]);
                }
            }

            bIsDone = true;
        }
	}

    void OnMouseDown()
    {
        for(int j = 0; j <= mB_R.Count - 1; j++)
        {
            mB_R[j].ClearBlock();
        }
    }
}
