using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour {

    public int CurrentBlockNumber = -1;

    void Update()
    {
        if(CurrentBlockNumber >= 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }

    }

}
