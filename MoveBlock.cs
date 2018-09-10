using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

    public float Distance = 10;

    void OnMouseDrag()
    {
        Vector3 MousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
        Vector3 BlockPostion = Camera.main.ScreenToWorldPoint(MousePostion);
        transform.position = BlockPostion;
    }
}
