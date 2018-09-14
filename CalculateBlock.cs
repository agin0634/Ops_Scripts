using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateBlock : MonoBehaviour {

    public BlockHolder A_Block;
    public BlockHolder B_Block;
    public Ops_Circle Ops;
    public int F_Number = 0;
    public GameObject Block_F_Prefab;
    public GameObject CurrentBlock_F;

	// Use this for initialization
	void Start ()
    {
        CurrentBlock_F = SpawnBlock_F();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(A_Block.CurrentBlockNumber != 0 && B_Block.CurrentBlockNumber != 0)
        {
            F_Number = Calculate(A_Block.CurrentBlockNumber, B_Block.CurrentBlockNumber, Ops.Ops_Current_mode);
            this.GetComponent<TextWithBlock>().BlockNumber = F_Number;
            CurrentBlock_F.GetComponent<TextWithBlock>().BlockNumber = F_Number;
        }
        else
        {
            this.GetComponent<TextWithBlock>().BlockNumber = -1;
            CurrentBlock_F.GetComponent<TextWithBlock>().BlockNumber = -1;
        }

        
	}

    GameObject SpawnBlock_F()
    {
        GameObject go = Instantiate(Block_F_Prefab, transform.position, transform.rotation);
        return go;
    }

    int Calculate (int A , int B , int ops_number)
    {
        int F = 0;
        if(ops_number == 0)
        {
            // A+B
            F = A + B;
        }
        else if(ops_number == 1)
        {
            // A-B
            F = A - B;
            if (F <= 0)
            {
                F = -1;
            }
        }
        else if(ops_number == 2)
        {
            // A*B
            F = A * B;
        }
        else
        {
            // A/B
            if( A % B == 0)
            {
                F = A / B;
            }
            else
            {
                F = -1;
            }
        }
        return F;
    }
}
