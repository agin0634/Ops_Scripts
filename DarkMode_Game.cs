using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkMode_Game : MonoBehaviour {

    public Color32 Dark_Color = new Color32(38, 48, 54, 255);
    public Color32 Bright_Color = new Color32(190, 171, 145, 255);

    public GameObject[] bG;
    public GameObject bH;
    public GameObject Ops_Circle;
    public GameObject Equal;
    

    public void DarkOn()
    {
        for(int i = 0; i <= bG.Length - 1; i++)
        {
            bG[i].GetComponent<SpriteRenderer>().color = Dark_Color;
        }
        bH.GetComponent<SpriteRenderer>().color = Bright_Color;
        Ops_Circle.GetComponent<Image>().color = Bright_Color;
        Equal.GetComponent<SpriteRenderer>().color = Bright_Color;

    }

    public void DarkOff()
    {
        for (int i = 0; i <= bG.Length - 1; i++)
        {
            bG[i].GetComponent<SpriteRenderer>().color = Bright_Color;
        }
        bH.GetComponent<SpriteRenderer>().color = Dark_Color;
        Ops_Circle.GetComponent<Image>().color = Dark_Color;
        Equal.GetComponent<SpriteRenderer>().color = Dark_Color;
    }
}
