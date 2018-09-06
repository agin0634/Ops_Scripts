using System.Collections;
using UnityEngine;

public class Ops_Circle : MonoBehaviour {

    public int[] Ops_mode = new int[] { 0, 1, 2, 3 };
    public int Ops_Current_mode = 0;

    public Sprite[] Ops_Sp;
    public SpriteRenderer sr = null;

    
	void Start () {
        if(sr == null)
        {
            sr = this.GetComponent<SpriteRenderer>();
        }
	}

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = this.GetComponent<Collider2D>();

            if (collider.OverlapPoint(wp))
            {
                if(Ops_Current_mode != 3)
                {
                    Ops_Current_mode++;
                }
                else
                {
                    Ops_Current_mode = 0;
                }
                
                Debug.Log(Ops_Current_mode);
            }
            else
            {
                Debug.Log("Miss!!");
            }

            ChangeSprite();
        }
	}

    void ChangeSprite()
    {
        if(Ops_Current_mode == 0)
        {
            sr.sprite = Ops_Sp[0];
        }
        else if(Ops_Current_mode == 1)
        {
            sr.sprite = Ops_Sp[1];
        }
        else if(Ops_Current_mode == 2)
        {
            sr.sprite = Ops_Sp[2];
        }
        else
        {
            sr.sprite = Ops_Sp[3];
        }
    }
}
