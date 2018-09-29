using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

    public float Distance = 10;
    public bool bIsDragging = false;
    public List<Collider2D> NearsetObject;
    public BlockHolder NearestBlock;
    public TextWithBlock TwB;
    public bool bCanbeDrag = true;
    public bool bBlockIsHold = false;

    void Update()
    {
        if (!TwB)
        {
            TwB = this.GetComponent<TextWithBlock>();
        }

        if (NearsetObject.Count != 0)
        {
            NearestBlock = GetNearestBlock();
        }
        if (!bIsDragging && NearestBlock)
        {
            transform.position = NearestBlock.transform.position;
            NearestBlock.GetComponent<Collider2D>().enabled = false;
            NearestBlock.CurrentBlockNumber = TwB.BlockNumber;
            this.transform.gameObject.SetActive(true);
            if(NearestBlock.tag == "Block_Holder")
            {
                bBlockIsHold = true;
            }
        }
        else
        {
            if (NearestBlock)
            {
                NearestBlock.GetComponent<Collider2D>().enabled = true;
                NearestBlock.CurrentBlockNumber = 0;
                bBlockIsHold = false;
            } 
        }
  
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Block_Holder" || Col.tag == "Block_Holder_R")
        {
            NearsetObject.Add(Col);
        }
    }

    void OnTriggerExit2D()
    {
        NearsetObject.Clear();
    }

    BlockHolder GetNearestBlock()
    {
        float NearestDistance = 100000;
        BlockHolder nearestBlock = null;

        for(int i = 0; i <= NearsetObject.Count - 1; i++)
        {
            float CurrentDistance = Vector3.Distance(NearsetObject[i].transform.position, transform.position);
            if( CurrentDistance < NearestDistance)
            {
                NearestDistance = CurrentDistance;
                nearestBlock = NearsetObject[i].GetComponent<BlockHolder>();
            }
        }
        return nearestBlock;
    }

    void OnMouseDown()
    {
        bIsDragging = true;
    }

    void OnMouseUp()
    {
        bIsDragging = false;
    }

    void OnMouseDrag()
    {
        if (bCanbeDrag)
        {
            Vector3 MousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
            Vector3 BlockPostion = Camera.main.ScreenToWorldPoint(MousePostion);
            transform.position = BlockPostion;
        }     
    }
}
