using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

    public float Distance = 10;
    public bool bIsDragging = false;
    public bool bIsBeHolding = false;
    public BlockHolder CurrentHolder = null;


    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col.tag == "Block_Holder")
        {
            if (bIsBeHolding)
            {
                if (Col.GetComponent<BlockHolder>() != CurrentHolder)
                {
                    CurrentHolder = null;
                    bIsBeHolding = false;
                }
            }      
        }
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
        Vector3 MousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
        Vector3 BlockPostion = Camera.main.ScreenToWorldPoint(MousePostion);
        transform.position = BlockPostion;
    }
}
