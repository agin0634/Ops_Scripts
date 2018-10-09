using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ops_Circle : MonoBehaviour {

    public int[] Ops_mode = new int[] { 0, 1, 2, 3 };
    public int Ops_Current_mode = 0;

    public Sprite[] Ops_Sp;
    public SpriteRenderer sr = null;
    private Button button { get { return GetComponent<Button>(); } }
    private Image image { get { return GetComponent<Image>(); } }

    
	void Start ()
    {
        button.onClick.AddListener(() => ChangeImage());

    }

	void Update ()
    {
        /*
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
            }

            ChangeImage();
        }*/
	}



    void ChangeImage()
    {
        if (Ops_Current_mode != 3)
        {
            Ops_Current_mode++;
        }
        else
        {
            Ops_Current_mode = 0;
        }

        if (Ops_Current_mode == 0)
        {
            image.sprite = Ops_Sp[0];
            
        }
        else if (Ops_Current_mode == 1)
        {
            image.sprite = Ops_Sp[1];
        }
        else if (Ops_Current_mode == 2)
        {
            image.sprite = Ops_Sp[2];
        }
        else
        {
            image.sprite = Ops_Sp[3];
        }
    }

    /*
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
    */
}
